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
    internal class GetAllPeliculasHandler : IRequestHandler<GetAllPeliculas, IEnumerable<PeliculaDto>>
    {
        private readonly IGenericRepository<Pelicula> _genericRepository;
        private readonly IMapper _mapper;

        public GetAllPeliculasHandler(IGenericRepository<Pelicula> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PeliculaDto>> Handle(GetAllPeliculas request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<PeliculaDto>>(await _genericRepository.GetAsync());
        }
    }
}
