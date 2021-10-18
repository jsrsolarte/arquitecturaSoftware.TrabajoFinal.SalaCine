using PracticaFinal.SalasCine.Domain.Entities;
using PracticaFinal.SalasCine.Domain.Exceptions;
using PracticaFinal.SalasCine.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Domain.Services
{
    [DomainService]
    public class SalasCineService : ISalasCineService
    {

        private readonly IGenericRepository<SalaDeCine> _salaCineRepository;
        private readonly IGenericRepository<Pelicula> _peliculaRepository;
        private readonly IGenericRepository<Funcion> _funcionRepository;

        public SalasCineService(IGenericRepository<SalaDeCine> salaCineRepository, IGenericRepository<Pelicula> peliculaRepository, IGenericRepository<Funcion> funcionRepository)
        {
            _salaCineRepository = salaCineRepository;
            _peliculaRepository = peliculaRepository;
            _funcionRepository = funcionRepository;
        }

        public async Task AddFunciones(Guid idSalaCine, Guid idPelicula, IEnumerable<Funcion> funciones)
        {
            var pelicula = await _peliculaRepository.GetByIdAsync(idPelicula);
            if (pelicula == null) throw new AppNotExistEntityException($"Pelicula con id {idPelicula} no existe");

            var salaCine = await _salaCineRepository.GetByIdAsync(idSalaCine);
            if (salaCine == null) throw new AppNotExistEntityException($"Sala de Cine con id {idSalaCine} no existe");

            foreach (var funcion in funciones)
            {
                funcion.SalaCine = salaCine;
                funcion.Pelicula = pelicula;
                await _funcionRepository.AddAsync(funcion);
            }
        }

        public async Task AddPelicula(Guid idSalaCine, Guid idPelicula)
        {
            var pelicula = await _peliculaRepository.GetByIdAsync(idPelicula);
            if (pelicula == null) throw new AppNotExistEntityException($"Pelicula con id {idPelicula} no existe");

            var salasCine = await _salaCineRepository.GetAsync(x => x.Id.Equals(idSalaCine), includeObjectProperties: x => x.Peliculas);
            var salaCine = salasCine.FirstOrDefault();
            if (salaCine == null) throw new AppNotExistEntityException($"Sala de Cine con id {idSalaCine} no existe");

            salaCine.Peliculas.Add(pelicula);

            await _salaCineRepository.UpdateAsync(salaCine);

        }

        public async Task<SalaDeCine> CreateSalaCine(SalaDeCine salaDeCine)
        {
            return await _salaCineRepository.AddAsync(salaDeCine);
        }
    }
}
