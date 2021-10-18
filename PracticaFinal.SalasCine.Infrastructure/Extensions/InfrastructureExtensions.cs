using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PracticaFinal.SalasCine.Domain.Ports;
using PracticaFinal.SalasCine.Infrastructure.Adapters;
using System;

namespace PracticaFinal.SalasCine.Infrastructure.Extensions
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection LoadRepositoryServices(this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            serviceCollection.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            var secretName = configuration.GetValue<string>("Database:ConnectionSecret");
            var databaseConnection = configuration.GetValue<string>(secretName);
            var schemaName = configuration.GetValue<string>("Database:SchemaName");
            serviceCollection.AddDbContext<PersistenceContext>(opt => opt.UseSqlServer(databaseConnection,
                sqlopts =>
                {
                    sqlopts.MigrationsHistoryTable("_MigrationHistory", schemaName);
                    sqlopts.EnableRetryOnFailure(5, TimeSpan.FromSeconds(20), null);
                }));
            return serviceCollection;
        }
    }
}
