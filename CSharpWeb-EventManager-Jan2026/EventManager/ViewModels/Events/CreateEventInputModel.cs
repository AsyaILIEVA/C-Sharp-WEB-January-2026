using System.ComponentModel.DataAnnotations;

using EventManager.Models;
using EventManager.Utilities.Validation;
using static EventManager.Common.DataValidation.Event;

namespace EventManager.ViewModels.Events
{
    public class CreateEventInputModel : IValidateObject
    {
        [MinLength(TitleMinLength)]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [MinLength(DescriptionMinLength)]
        [MaxLength(DescriptionMaxLength)]
        public string? Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        [Range(MinParticipantsValue, MaxParticipantsValue)]
        public int MaxParticipants { get; set; }

        [Required]
        [ExistanceCheck(typeof(Category))]
        public int CategoryId { get; set; }

        public IEnumerable<Category>? Categories { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate >= EndDate)
            {
                yield return new ValidationResult("The start date must be earlier than the end date.",
                    new[] { nameof(EndDate) });
            }
        }
    }
}
