using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PracticaFinal.SalasCine.Api.Filters;
using PracticaFinal.SalasCine.Domain.Extensions;
using PracticaFinal.SalasCine.Domain.Ports;
using PracticaFinal.SalasCine.Infrastructure.Adapters;
using PracticaFinal.SalasCine.Infrastructure.Extensions;
using System;
using System.Linq;
using System.Reflection;

namespace PracticaFinal.SalasCine.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMediatR(Assembly.Load("PracticaFinal.SalasCine.Application"),
               typeof(Startup).Assembly);

            var applicationAssemblyName = typeof(Startup).Assembly.GetReferencedAssemblies()
                .FirstOrDefault(x => x.Name?.Equals("PracticaFinal.SalasCine.Application",
                    StringComparison.InvariantCulture) == true);

            if (applicationAssemblyName != null)
                services.AddAutoMapper(Assembly.Load(applicationAssemblyName.FullName));

            services.AddCors();

            services.AddSingleton<IFileRepository, BlobStorageFileRepository>();

            services.AddSingleton(cfg => Configuration);

            services.LoadRepositoryServices(Configuration);
            services.LoadDomainServices();

            services.AddControllers(mvcOpts => mvcOpts.Filters.Add(typeof(AppExceptionFilterAttribute)));

            services.AddHttpContextAccessor();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PracticaFinal.SalasCine.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PracticaFinal.SalasCine.Api v1"));

            app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true)
               .AllowCredentials());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
