using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Visitantes.Application;
using Visitantes.Application.Contratos;
using Visitantes.Persistence;
using Visitantes.Persistence.Contexto;
using Visitantes.Persistence.Contratos;

namespace Visitantes.API
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
            services.AddDbContext<VisitantesContexto>(
                //context => context.UseSqlServer(Configuration.GetConnectionString("CasaServer"))
                context => context.UseSqlServer(Configuration.GetConnectionString("Default"))
            );
            services.AddControllers();
            services.AddScoped<IVisitanteService, VisitanteService>();
            services.AddScoped<IGeralPersistence, GeralPersistence>();
            services.AddScoped<IVisitantesPersistence, VisitantesPersistence>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Visitantes.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Visitantes.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
