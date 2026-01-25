using GarageApp.Models;
using GarageApp.Models.Enums;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageApp.Data.Configuration
{
    public class CarEntityTypeConfiguration : IEntityTypeConfiguration<Car>
    {
        private readonly Car[] Cars =
            {
            new Car
            {
                Id = 1,
                Make = "BMW",
                Model = "M3",
                Year = 2021,
                CarChassisType = CarChassisType.Sedan,
                IsAvailable = true,
                GarageId = Guid.Parse("b0fcfba8-dedc-4654-9f8d-636b9e19a8d0")
            },
            new Car
            {
                Id = 2,
                Make = "Audi",
                Model = "Q7",
                Year = 2019,
                CarChassisType = CarChassisType.SUV,
                IsAvailable = false,
                GarageId = Guid.Parse("7147ac98-3245-4031-9674-2fa1fe564408")
            },
            new Car
            {
                Id = 3,
                Make = "Mazda",
                Model = "M6",
                Year = 2022,
                CarChassisType = CarChassisType.Roadster,
                IsAvailable = true,
                GarageId = Guid.Parse("2c2fca1e-ad73-46a1-b4ee-2809f422733f")
            },
            new Car
            {
                Id = 4,
                Make = "Toyota",
                Model = "Corolla",
                Year = 2020,
                CarChassisType = CarChassisType.Hatchback,
                IsAvailable = true,
                GarageId = Guid.Parse("b0fcfba8-dedc-4654-9f8d-636b9e19a8d0")
            }
        };

        public void Configure(EntityTypeBuilder<Car> entity)
        {
            entity.HasData(Cars);
        }
    }
}