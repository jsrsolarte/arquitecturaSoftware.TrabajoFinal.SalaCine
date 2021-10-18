using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PracticaFinal.SalasCine.Api.Validations
{
    public class FileSizeValidationAttribute: ValidationAttribute
    {
        private readonly int _maxSize;

        public FileSizeValidationAttribute(int maxSize)
        {
            _maxSize = maxSize;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return value == null
                ? ValidationResult.Success
                : value is not IFormFile formFile
                ? ValidationResult.Success
                : formFile.Length > _maxSize * 1024 * 1024
                ? new ValidationResult($"El peso del archivo no debe ser mayor a {_maxSize}mb")
                : ValidationResult.Success;
        }
    }
}
