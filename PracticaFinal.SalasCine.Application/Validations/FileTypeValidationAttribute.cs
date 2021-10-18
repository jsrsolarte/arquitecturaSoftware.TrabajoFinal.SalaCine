using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PracticaFinal.SalasCine.Application.Validations
{
    public class FileTypeValidationAttribute : ValidationAttribute
    {
        private readonly string[] _validTypes;
        public FileTypeValidationAttribute(TypeFileGroup grupoTipoArchivo)
        {
            if (grupoTipoArchivo == TypeFileGroup.Image)
            {
                _validTypes = new string[] { "image/jpeg", "image/jpg", "image/png", "image/gif" };
            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return value == null
                ? ValidationResult.Success
                : value is not IFormFile formFile
                ? ValidationResult.Success
                : !_validTypes.Contains(formFile.ContentType)
                ? new ValidationResult($"El tipo del archivo debe ser uno de los siguientes: {string.Join(", ", _validTypes)}")
                : ValidationResult.Success;
        }
    }

    public enum TypeFileGroup
    {
        Image
    }
}
