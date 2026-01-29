using System.ComponentModel.DataAnnotations;
using static EventManager.Common.DataValidation.Category;

namespace EventManager.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Event> Events { get; set; }
            = new HashSet<Event>(); 
    }
}
