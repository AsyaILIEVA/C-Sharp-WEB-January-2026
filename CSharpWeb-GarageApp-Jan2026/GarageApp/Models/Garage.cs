using System.ComponentModel.DataAnnotations;
using static GarageApp.Common.EntityValidation;


namespace GarageApp.Models
{
    public class Garage
    {
        //public Garage() 
        //{
        //    Id = new Guid();
        //}

        [Key]
        public Guid Id { get; set; } //= new Guid();

        [Required]
        [MaxLength(GarageNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(GarageLocationMaxLength)]
        public string Location { get; set; } = null!;

        public ICollection<Car> Cars { get; set; }
                = new HashSet<Car>();


    }
}
