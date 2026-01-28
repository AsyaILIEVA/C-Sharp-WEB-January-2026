using BookShelf.Data;
using BookShelf.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShelf.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookShelfDbContext dbContext;

        public BooksController(BookShelfDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Book> books = dbContext
                .Books
                .Include(b => b.Author)
                .AsNoTracking()
                .OrderBy(b => b.Title)
                .ToArray();

            return View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<Author> authors = dbContext
                .Authors              
                .AsNoTracking()
                .OrderBy(a => a.Name)
                .ToArray();

            ViewData["Authors"] = authors;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Book inputModel)
        {
           // return Json(inputModel);
            try
            {
                Author? refAuthor = dbContext
                    .Authors
                    .Find(inputModel.AuthorId);

                if (refAuthor == null)
                {
                    //ModelState.AddModelError(nameof(Book), "Invalid Author selected!");
                    //return View();
                    return BadRequest();
                }

                dbContext.Books.Add(inputModel);
                dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
                return BadRequest();
            }
        }
    }
}
