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

namespace PracticaFinal.SalasCine.Application.Queries.Actores
{
    public class GetAllActoresHandler : IRequestHandler<GetAllActores, IEnumerable<ActorDto>>
    {

        private readonly IGenericRepository<Actor> _actorRepository;
        private readonly IMapper _mapper;

        public GetAllActoresHandler(IGenericRepository<Actor> actorRepository, IMapper mapper)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ActorDto>> Handle(GetAllActores request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<ActorDto>>(await _actorRepository.GetAsync());
        }
    }
}
