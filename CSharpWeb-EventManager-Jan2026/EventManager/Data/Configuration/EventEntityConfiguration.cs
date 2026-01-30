using EventManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.Data.Configuration
{
    public class EventEntityConfiguration : IEntityTypeConfiguration<Event>
    {
        private readonly IEnumerable<Event> Events = new List<Event>()
        {
            new Event
            {
                Id = 1,
                Title = "Tech Innovations 2024",
                Description = "A conference on emerging technologies.",
                StartDate = new DateTime(2024, 9, 10),
                EndDate = new DateTime(2024, 9, 12),
                MaxParticipants = 200,
                CategoryId = 1
            },
            new Event
            {
                Id = 2,
                Title = "C# Advanced Workshop",
                Description = "Deep dive in C# features.",
                StartDate = new DateTime(2024, 9, 5),
                EndDate = new DateTime(2024, 9, 7),
                MaxParticipants = 200,
                CategoryId = 2
            }
        };

        public void Configure(EntityTypeBuilder<Event> entity)
        {
            entity.HasData(Events);
        }
    }
}
