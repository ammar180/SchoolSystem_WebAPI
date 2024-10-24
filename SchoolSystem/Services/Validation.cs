using SchoolSystem.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Services
{
    public class Validation
    {
        public bool IsValid { get; set; }
        public string GetValidationResult(Student s)
        {
            var context = new ValidationContext(s, serviceProvider: null, items: null);

            var validationResults = new List<ValidationResult>();

            IsValid = Validator.TryValidateObject(s, context, validationResults, true);

            if (!IsValid)
            {
                return string.Join('\n',
                validationResults?.FirstOrDefault(x => x.MemberNames?.First() == nameof(s.UserName))?.ErrorMessage + '\n' ?? "",
                validationResults?.FirstOrDefault(x => x.MemberNames?.First() == nameof(s.StudentFullName))?.ErrorMessage ?? ""
                ); ;
            }

            return "";
        }
    }
}