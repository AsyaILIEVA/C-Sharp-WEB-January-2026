using GarageApp.Models;
using Microsoft.EntityFrameworkCore;

namespace GarageApp.Data
{
    public class GarageAppDbContext : DbContext
    {
        //Proper constructor that will be used by ASP.NET Core
        //while using DI
        public GarageAppDbContext(DbContextOptions<GarageAppDbContext> dbContextOptions) 
            : base(dbContextOptions) 
        {

        }

        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<Garage> Garages { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GarageAppDbContext).Assembly);
        }

    }
}
