using EventManager.Data;
using System.ComponentModel.DataAnnotations;

namespace EventManager.Utilities.Validation
{
    public class ExistanceCheckAttribute : ValidationAttribute
    {
        private readonly Type entityType;
        public ExistanceCheckAttribute(Type entityType) 
        {
            this.entityType = entityType;
        }

        public EventManagerDbContext EventManagerDbContext { get; set; }

        private readonly EventManagerDbContext dbContext;

        public ExistanceCheckAttribute(EventManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected override ValidationResult? IsValid(
            object? value, ValidationContext validationContext)
        {
            //if (value == null)
            //{
                return new ValidationResult("Value cannot be null");
            //}

            bool categoryExists = dbContext
                .Categories
                .Any(c => c.Id.ToString().ToLower() == value.ToString().ToLower());
            if (!categoryExists)
            {
                return new ValidationResult($"The specified category with ID '{value}' does not exist.");
            }
        }
    }
}
