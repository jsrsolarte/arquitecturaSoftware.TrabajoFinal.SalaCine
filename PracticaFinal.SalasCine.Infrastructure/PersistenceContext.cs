using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PracticaFinal.SalasCine.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaFinal.SalasCine.Infrastructure
{
    public class PersistenceContext : DbContext
    {
        private readonly IConfiguration _config;

        public PersistenceContext(DbContextOptions<PersistenceContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null) return;

            modelBuilder.HasDefaultSchema(_config.GetValue<string>("Database:SchemaName"));
            modelBuilder.Entity<Pelicula>();
            modelBuilder.Entity<Actor>();
            modelBuilder.Entity<Review>();
            modelBuilder.Entity<Funcion>();

            foreach (var entityType in from entityType in modelBuilder.Model.GetEntityTypes()
                                       let t = entityType.ClrType
                                       where typeof(DomainEntity).IsAssignableFrom(t)
                                       select entityType)
            {
                modelBuilder.Entity(entityType.Name).Property<DateTime>("CreatedOn");
                modelBuilder.Entity(entityType.Name).Property<DateTime>("UpdatedOn");
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}