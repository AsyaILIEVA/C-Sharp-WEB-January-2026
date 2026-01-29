using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static EventManager.Common.DataValidation.Registration;


namespace EventManager.Models
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ParticipantNameMaxLength)]
        public string ParticipantName { get; set; } = null!;

        [Required]
        [MaxLength(EmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }

        public virtual Event Event { get; set; } = null!;
    }
}
