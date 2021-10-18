using Microsoft.EntityFrameworkCore;
using PracticaFinal.SalasCine.Domain.Entities;
using PracticaFinal.SalasCine.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Infrastructure.Adapters
{
    public class GenericRepository<E> : IGenericRepository<E> where E : DomainEntity
    {
        private readonly PersistenceContext _Context;

        public GenericRepository(PersistenceContext context)
        {
            _Context = context ?? throw new ArgumentNullException(nameof(context), "No hay dbcontext disponible");
        }

        public async Task<IEnumerable<E>> GetAsync(Expression<Func<E, bool>> filter = null,
            Func<IQueryable<E>, IOrderedQueryable<E>> orderBy = null,
            string includeStringProperties = "", bool isTracking = false)
        {
            IQueryable<E> query = _Context.Set<E>();

            if (filter != null) query = query.Where(filter);

            if (!string.IsNullOrEmpty(includeStringProperties))
                foreach (var includeProperty in includeStringProperties.Split
                    (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(includeProperty);

            return orderBy != null
                ? await orderBy(query).ToListAsync().ConfigureAwait(false)
                : !isTracking
                ? await query.AsNoTracking().ToListAsync().ConfigureAwait(false)
                : await query.ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<E>> GetAsync(Expression<Func<E, bool>> filter = null,
            Func<IQueryable<E>, IOrderedQueryable<E>> orderBy = null,
            bool isTracking = false, params Expression<Func<E, object>>[] includeObjectProperties)
        {
            IQueryable<E> query = _Context.Set<E>();

            if (filter != null) query = query.Where(filter);

            if (includeObjectProperties != null)
                foreach (var include in includeObjectProperties)
                    query = query.Include(include);

            return orderBy != null
                ? await orderBy(query).ToListAsync().ConfigureAwait(false)
                : !isTracking
                ? await query.AsNoTracking().ToListAsync().ConfigureAwait(false)
                : await query.ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<E>> GetAsync(IEnumerable<Expression<Func<E, bool>>> filters,
            Func<IQueryable<E>, IOrderedQueryable<E>> orderBy = null, string includeStringProperties = "",
            bool isTracking = false)
        {
            IQueryable<E> query = _Context.Set<E>();

            query = filters.Aggregate(query, (current, filter) => current.Where(filter));

            if (!string.IsNullOrEmpty(includeStringProperties))
                query = includeStringProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return orderBy != null
                ? await orderBy(query).ToListAsync().ConfigureAwait(false)
                : !isTracking
                ? await query.AsNoTracking().ToListAsync().ConfigureAwait(false)
                : await query.ToListAsync().ConfigureAwait(false);
        }

        public async Task<E> GetByIdAsync(object id)
        {
            return await _Context.Set<E>().FindAsync(id).ConfigureAwait(false);
        }

        public async Task<E> AddAsync(E entity)
        {
            if (entity != null)
            {
                var item = _Context.Set<E>();
                item.Add(entity);
                await CommitAsync().ConfigureAwait(false);
            }

            return entity;
        }

        public async Task UpdateAsync(E entity)
        {
            if (entity != null)
            {
                var item = _Context.Set<E>();
                item.Update(entity);
                await CommitAsync().ConfigureAwait(false);
            }
        }

        public async Task DeleteAsync(E entity)
        {
            if (entity != null)
            {
                _Context.Set<E>().Remove(entity);
                await CommitAsync().ConfigureAwait(false);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _Context.Dispose();
        }

        public async Task CommitAsync()
        {
            _Context.ChangeTracker.DetectChanges();

            foreach (var entry in _Context.ChangeTracker.Entries())
                switch (entry.State)
                {
                    case EntityState.Added:
                        if (entry.Metadata.FindProperty("CreatedOn") != null)
                        {

                            entry.Property("CreatedOn").CurrentValue = DateTime.UtcNow;
                        }
                        break;
                    case EntityState.Modified:
                        if (entry.Metadata.FindProperty("UpdatedOn") != null)
                        {
                            entry.Property("UpdatedOn").CurrentValue = DateTime.UtcNow;
                        }
                        break;
                    case EntityState.Unchanged:
                        break;
                    default:
                        throw new InvalidOperationException("Unexpected value state = " + entry.State);
                }

            await _Context.CommitAsync().ConfigureAwait(false);
        }
    }
}