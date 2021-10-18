using AutoMapper;
using MediatR;
using PracticaFinal.SalasCine.Application.Dtos;
using PracticaFinal.SalasCine.Domain.Entities;
using PracticaFinal.SalasCine.Domain.Ports;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Application.Queries.SalasCine
{
    public class GetAllSalasCineHandler : IRequestHandler<GetAllSalasCine, IEnumerable<SalaCineDto>>
    {
        private readonly IGenericRepository<SalaDeCine> _salaCineRepository;
        private readonly IMapper _mapper;

        public GetAllSalasCineHandler(IGenericRepository<SalaDeCine> salaCineRepository, IMapper mapper)
        {
            _salaCineRepository = salaCineRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SalaCineDto>> Handle(GetAllSalasCine request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<SalaCineDto>>(await _salaCineRepository.GetAsync(includeObjectProperties: x=>x.Peliculas));
        }
    }
}
