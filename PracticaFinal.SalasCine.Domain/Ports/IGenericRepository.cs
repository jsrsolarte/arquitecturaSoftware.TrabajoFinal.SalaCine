using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PracticaFinal.SalasCine.Domain.Entities;

namespace PracticaFinal.SalasCine.Domain.Ports
{
    public interface IGenericRepository<T> : IDisposable
        where T : DomainEntity

    {
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeStringProperties = "",
            bool isTracking = false);

        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            bool isTracking = false, params Expression<Func<T, object>>[] includeObjectProperties);

        Task<IEnumerable<T>> GetAsync(IEnumerable<Expression<Func<T, bool>>> filters,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeStringProperties = "",
            bool isTracking = false);

        Task<T> GetByIdAsync(object id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}