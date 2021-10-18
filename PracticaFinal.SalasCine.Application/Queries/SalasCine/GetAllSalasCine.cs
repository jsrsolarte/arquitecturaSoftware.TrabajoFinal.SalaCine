using MediatR;
using PracticaFinal.SalasCine.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Application.Queries.SalasCine
{
    public class GetAllSalasCine: IRequest<IEnumerable<SalaCineDto>>
    {
    }
}
