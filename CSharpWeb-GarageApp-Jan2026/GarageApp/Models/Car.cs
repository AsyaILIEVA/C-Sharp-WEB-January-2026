using GarageApp.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GarageApp.Common.EntityValidation;

namespace GarageApp.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CarMakeMaxLength)]
        public string Make { get; set; } = null!;

        [Required]
        [MaxLength(CarModelMaxLength)]
        public string Model { get; set; } = null!;

        public int Year { get; set; }

        public CarChassisType CarChassisType { get; set; }

        public bool IsAvailable { get; set; }

        [Required]
        [ForeignKey(nameof(Garage))]
        public Guid GarageId { get; set; }

        public virtual Garage Garage { get; set; } = null!;

    }
}