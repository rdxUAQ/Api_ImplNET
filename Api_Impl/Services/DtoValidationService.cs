using System.ComponentModel.DataAnnotations;

namespace ApiImpl.Services{
    public class DtoValidationService
    {
        public bool TryValidateDto<T>(T? dto, out List<ValidationResult> results) { 

            var context = new ValidationContext(dto);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(dto, context, results, true);

        }

    }
}