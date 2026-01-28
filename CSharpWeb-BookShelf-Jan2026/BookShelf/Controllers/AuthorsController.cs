using BookShelf.Data;
using BookShelf.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShelf.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly BookShelfDbContext dbContext;

        public AuthorsController(BookShelfDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Author> authors = dbContext
                .Authors
                .AsNoTracking()
                .OrderBy(a => a.Name)
                .ThenBy(a => a.Country)
                .ThenBy(a => a.Id)
                .ToList();

            return this.View(authors);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id <= 0) 
            {
                return BadRequest();
            }

            Author? author = dbContext
                .Authors
                .Include(a => a.Books)
                .AsNoTracking()
                .AsSplitQuery()
                .SingleOrDefault(a => a.Id == id);

            if (author == null)
            {
                return NotFound();
            }

            return this.View(author);
        }
    }
}
