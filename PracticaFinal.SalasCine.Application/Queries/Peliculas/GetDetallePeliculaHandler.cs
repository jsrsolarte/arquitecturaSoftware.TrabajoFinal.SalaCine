using AutoMapper;
using MediatR;
using PracticaFinal.SalasCine.Application.Dtos;
using PracticaFinal.SalasCine.Domain.Entities;
using PracticaFinal.SalasCine.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Application.Queries.Peliculas
{
    public class GetDetallePeliculaHandler : IRequestHandler<GetDetallePelicula, PeliculaDetalleDto>
    {

        private readonly IGenericRepository<Pelicula> _peliculaRepository;
        private readonly IMapper _mapper;

        public GetDetallePeliculaHandler(IGenericRepository<Pelicula> peliculaRepository, IMapper mapper)
        {
            _peliculaRepository = peliculaRepository;
            _mapper = mapper;
        }

        public async Task<PeliculaDetalleDto> Handle(GetDetallePelicula request, CancellationToken cancellationToken)
        {
            var peliculas = await _peliculaRepository.GetAsync(x => x.Id.Equals(request.Id), null, false, x => x.Actores, x => x.SalasCine);
            return _mapper.Map<PeliculaDetalleDto>(peliculas.FirstOrDefault());
        }
    }
}
