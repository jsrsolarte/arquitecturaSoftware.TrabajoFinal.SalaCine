using AutoMapper;
using MediatR;
using PracticaFinal.SalasCine.Application.Dtos;
using PracticaFinal.SalasCine.Domain.Entities;
using PracticaFinal.SalasCine.Domain.Ports;
using System.Threading;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Application.Commands.SalasCine
{
    public class CreateSalaCineHandler : IRequestHandler<CreateSalaCine, SalaCineDto>
    {
        private readonly ISalasCineService _salaCineService;
        private readonly IMapper _mapper;
        public CreateSalaCineHandler(ISalasCineService salaCineService, IMapper mapper)
        {
            _salaCineService = salaCineService;
            _mapper = mapper;
        }

        public async Task<SalaCineDto> Handle(CreateSalaCine request, CancellationToken cancellationToken)
        {
            var salaCineCreated = await _salaCineService.CreateSalaCine(_mapper.Map<SalaDeCine>(request));
            return _mapper.Map<SalaCineDto>(salaCineCreated);
        }
    }
}
