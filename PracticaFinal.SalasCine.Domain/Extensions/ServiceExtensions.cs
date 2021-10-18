using Microsoft.Extensions.DependencyInjection;
using PracticaFinal.SalasCine.Domain.Services;
using System;
using System.Linq;

namespace PracticaFinal.SalasCine.Domain.Extensions
{
    public static class ServiceExtensions
    {
        public static void LoadDomainServices(this IServiceCollection servicesCollection)
        {
            var services = AppDomain.CurrentDomain.GetAssemblies().Where(assembly =>
                    assembly.FullName?.Contains("Domain", StringComparison.InvariantCulture) == true)
                .SelectMany(s => s.GetTypes())
                .Where(p => p.CustomAttributes.Any(x => x.AttributeType == typeof(DomainServiceAttribute)));


            foreach (var service in services)
            {
                // interfaces in Domain layer, ignoring interfaces in other namespaces
                var sInterface = service.GetInterfaces().FirstOrDefault(i =>
                    i.FullName?.Contains("Domain", StringComparison.InvariantCulture) == true);
                if (sInterface != null) servicesCollection.AddTransient(sInterface, service);
            }
        }
    }
}
