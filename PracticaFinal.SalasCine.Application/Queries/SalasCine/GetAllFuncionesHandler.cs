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

namespace PracticaFinal.SalasCine.Application.Queries.SalasCine
{
    public class GetAllFuncionesHandler : IRequestHandler<GetAllFunciones, IEnumerable<FuncionDto>>
    {
        private readonly IGenericRepository<Funcion> _funcionRepository;
        private readonly IMapper _mapper;

        public GetAllFuncionesHandler(IGenericRepository<Funcion> funcionRepository, IMapper mapper)
        {
            _funcionRepository = funcionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FuncionDto>> Handle(GetAllFunciones request, CancellationToken cancellationToken)
        {
            var funciones = await _funcionRepository.GetAsync(x => x.SalaCine.Id.Equals(request.IdSalaCine) && x.Pelicula.Id.Equals(request.IdPelicula));
            return _mapper.Map<IEnumerable<FuncionDto>>(funciones);
        }
    }
}
