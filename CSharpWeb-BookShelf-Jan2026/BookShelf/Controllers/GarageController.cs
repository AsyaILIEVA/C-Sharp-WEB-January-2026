using GarageApp.Data;
using GarageApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GarageApp.Controllers
{
    public class GarageController : Controller
    {
        private readonly GarageAppDbContext dbContext;

        // I. Constructor Injection - Most common in Controllers
        // ASP.NET Core will make sure that new instance of GarageAppDbContext is passed when the GarageController is created.
        // GarageController is created when user enters URL /Garage/*

        public GarageController(GarageAppDbContext dbContext)
        {
            //store the injected instance in a local field
            this.dbContext = dbContext;        
        }

        //// II. Property Injection
        //[FromServices]
        //public GarageAppDbContext GarageAppDbContext { get; set; }

        //// III. Method Injection
        //public IActionResult Index([FromServices]GarageAppDbContext dbContext)
        //{
        //    return Ok("I am at Garagecontroller/Index.");
        //}

        //Default HttpMethod of ACTION is GET
        [HttpGet]
        public IActionResult Index()
        {
            Garage[] allGarages = dbContext
                .Garages
                .Include(g => g.Cars)
                .AsSplitQuery()
                .AsNoTracking()
                .ToArray();

            return this.View(allGarages);
        }

        [HttpGet]
        public IActionResult Details(string? id) 
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }

            bool isGuidValid = Guid.TryParse(id, out Guid guidId);
            if (!isGuidValid) 
            {
                return BadRequest();
            }

            Garage? garage = dbContext
                .Garages
                .Include(g => g.Cars)
                .SingleOrDefault(g => g.Id == guidId);
            if (garage == null)
            {
                return NotFound();
            }

            return this.View(garage);
        }
    }
}
