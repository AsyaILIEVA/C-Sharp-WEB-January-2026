using EventManager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EventManager.Models;
using EventManager.ViewModels.Events;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace EventManager.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventManagerDbContext dbContext;

        public EventsController(EventManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Event> allEvents = dbContext
                .Events
                .Include(e => e.Category)
                .AsNoTracking()
                .OrderBy(e => e.Title)
                .ToArray();

            //return Ok("Index of Events"); //when type /Events
            return View(allEvents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<Category> allCategories = dbContext
                .Categories                
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .ToArray();

            CreateEventInputModel inputModel = new CreateEventInputModel()
            {
                //Title = "Event Title...",
                Categories = allCategories,
            };

            return View(inputModel);
        }
        [HttpPost]
        public IActionResult Create(CreateEventInputModel inputModel)
        {
            IEnumerable<Category> allCategories = FetchCategories();
            if (!ModelState.IsValid)
            {
                inputModel.Categories = allCategories;

                return View(inputModel);
            }

            bool isSelectedCategoryValid=allCategories
                .Any(c => c.Id == inputModel.CategoryId);
            if (!isSelectedCategoryValid)
            {
                ModelState.AddModelError(nameof(inputModel.CategoryId), "Invalid category is selected!");

                return View(inputModel);
            }

            if (inputModel.StartDate >= inputModel.EndDate)
            {
                ModelState.AddModelError(nameof(inputModel.EndDate),
                    "Event EndDate can't be before or equal to the Event StartDate");

                return View(inputModel);
            }

            try
            {
                Event newEvent = new Event()
                {
                    Title = inputModel.Title,
                    Description = inputModel.Description,
                    StartDate = inputModel.StartDate,
                    EndDate = inputModel.EndDate,
                    MaxParticipants = inputModel.MaxParticipants,
                    CategoryId = inputModel.CategoryId,
                };

                dbContext.Events.Add(newEvent);
                dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                return View("Error");
            }
            
            return RedirectToAction(nameof(Index));
        }

        private IEnumerable<Category> FetchCategories() 
        { 
            return dbContext
                .Categories
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .ToArray();
        }
    }
}
