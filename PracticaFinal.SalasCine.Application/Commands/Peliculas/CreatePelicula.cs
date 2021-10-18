using MediatR;
using Microsoft.AspNetCore.Http;
using PracticaFinal.SalasCine.Api.Validations;
using PracticaFinal.SalasCine.Application.Dtos;
using PracticaFinal.SalasCine.Application.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace PracticaFinal.SalasCine.Application.Commands.Peliculas
{
    public class CreatePelicula : IRequest<PeliculaDto>
    {
        [Required]
        public string Titulo { get; set; }
        public DateTime FechaEstreno { get; set; }
       
    }
}
