using EventManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.Data.Configuration
{
    public class RegistrationEntityConfiguration : IEntityTypeConfiguration<Registration>
    {
        private readonly IEnumerable<Registration> Registrations = new List<Registration>()
        {
            new Registration
            {
                Id = 1,
                ParticipantName = "Peter Kalan",
                Email = "siyul@abv.bg",
                EventId = 1
            },
            new Registration
            {
                Id = 2,
                ParticipantName = "Max Inman",
                Email = "maxin@gmail.com",
                EventId = 2
            },
            new Registration
            {
                Id = 3,
                ParticipantName = "Carla Merini",
                Email = "carol@yahoo.com",
                EventId = 1
            }
        };

        public void Configure(EntityTypeBuilder<Registration> entity)
        {
            entity.HasData(Registrations);
        }
    }


}
