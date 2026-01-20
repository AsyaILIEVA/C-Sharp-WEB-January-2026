using GarageApp.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GarageApp.Data.Configuration
{
    public class GarageEntityTypeConfiguration : IEntityTypeConfiguration<Garage>
    {
        private readonly Garage[] Garages =
            {
            new Garage
            {
                Id = Guid.Parse("b0fcfba8-dedc-4654-9f8d-636b9e19a8d0"),
                Name = "Downtown Auto Garage",
                Location = "Sofia Center"
            },
            new Garage
            {
                Id = Guid.Parse("7147ac98-3245-4031-9674-2fa1fe564408"),
                Name = "Westside Performance Garage",
                Location = "Plovdiv West"
            },
            new Garage
            {
                Id = Guid.Parse("2c2fca1e-ad73-46a1-b4ee-2809f422733f"),
                Name = "Mountain View Garage",
                Location = "Varna Industrial Zone"
            }
        };

        public void Configure(EntityTypeBuilder<Garage> entity)
        {
            entity.HasData(Garages);
        }
    }
}
