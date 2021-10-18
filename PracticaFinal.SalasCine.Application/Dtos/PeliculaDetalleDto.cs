using PracticaFinal.SalasCine.Domain.Entities;
using System;
using System.Collections.Generic;

namespace PracticaFinal.SalasCine.Application.Dtos
{
    public class PeliculaDetalleDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public bool EnCines => SalasCine.Count > 0;
        public DateTime FechaEstreno { get; set; }
        public List<ActorDto> Actores { get; set; }
        public List<GeneroDto> Generos { get; set; }
        public string Poster { get; set; }
        public List<SalaCineDto> SalasCine { get; set; }
    }
}
