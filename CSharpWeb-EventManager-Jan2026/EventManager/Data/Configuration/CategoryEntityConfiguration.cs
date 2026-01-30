using EventManager.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventManager.Data.Configuration
{    
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        private readonly IEnumerable<Category> Categories = new List<Category>()
        {
            new Category{ Id = 1, Name = "Conference"},
            new Category{ Id = 2, Name = "Workshop"},
            new Category{ Id = 3, Name = "Webinar"}
        };

        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasData(Categories);
        }       
    }
}
