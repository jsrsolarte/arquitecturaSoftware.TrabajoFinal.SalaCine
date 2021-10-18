using MediatR;
using Microsoft.AspNetCore.Http;
using PracticaFinal.SalasCine.Api.Validations;
using PracticaFinal.SalasCine.Application.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Application.Commands.Actores
{
    public class UploadActorPhoto: IRequest
    {
        [Required]
        public Guid IdActor { get; set; }

        [Required]
        [FileSizeValidation(4)]
        [FileTypeValidation(TypeFileGroup.Image)]
        public IFormFile Foto { get; set; }
    }
}
