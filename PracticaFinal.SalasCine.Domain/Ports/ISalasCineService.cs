using PracticaFinal.SalasCine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Domain.Ports
{
    public interface ISalasCineService
    {
        Task<SalaDeCine> CreateSalaCine(SalaDeCine salaDeCine);

        Task AddPelicula(Guid idSalaCine, Guid idPelicula);

        Task AddFunciones(Guid idSalaCine, Guid idPelicula, IEnumerable<Funcion> funciones);
    }
}
