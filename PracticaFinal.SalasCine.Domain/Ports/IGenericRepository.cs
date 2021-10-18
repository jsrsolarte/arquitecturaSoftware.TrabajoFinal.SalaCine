using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Epm.Autogeneradores.PreRegistro.Domain.Entities;

namespace Epm.Autogeneradores.PreRegistro.Domain.Ports
{
    public interface IGenericRepository<TE> : IDisposable
        where TE : DomainEntity

    {
        Task<IEnumerable<TE>> GetAsync(Expression<Func<TE, bool>> filter = null,
            Func<IQueryable<TE>, IOrderedQueryable<TE>> orderBy = null, string includeStringProperties = "",
            bool isTracking = false);

        Task<IEnumerable<TE>> GetAsync(Expression<Func<TE, bool>> filter = null,
            Func<IQueryable<TE>, IOrderedQueryable<TE>> orderBy = null,
            bool isTracking = false, params Expression<Func<TE, object>>[] includeObjectProperties);

        Task<IEnumerable<TE>> GetAsync(IEnumerable<Expression<Func<TE, bool>>> filters,
            Func<IQueryable<TE>, IOrderedQueryable<TE>> orderBy = null,
            string includeStringProperties = "",
            bool isTracking = false);

        Task<TE> GetByIdAsync(object id);
        Task<TE> AddAsync(TE entity);
        Task UpdateAsync(TE entity);
        Task DeleteAsync(TE entity);
    }
}