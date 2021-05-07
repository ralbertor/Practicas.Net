using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Repository;
using Catalog.RepositoriesImp;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Oracle.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Catalog.Entidades;
using Catalog.Services;
using Catalog.ServicesImp;
using Microsoft.Extensions.Options;
using Catalog.RepositoriesImpl;
using Catalog.RepositoryImpl;
using Catalog.RepositoryImp;

namespace Catalog
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
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            services.AddAutoMapper(typeof(Mapper));
            
            services.AddDbContext<OracleContext>(opt => opt
                    .UseLazyLoadingProxies()
                    .UseOracle(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<DiagnosticoRepository, DiagnosticoRepositoryImp>();
            services.AddScoped<DiagnosticoService, DiagnosticoServiceImp>();
            services.AddScoped<CitaRepository, CitaRepositoryImp>();
            services.AddScoped<CitaService, CitaServiceImp>();
            services.AddScoped<MedicoRepository, MedicoRepositoryImp>();
            services.AddScoped<MedicoService, MedicoServiceImp>();
            services.AddScoped<PacienteRepository, PacienteRepositoryImp>();
            services.AddScoped<PacienteService, PacienteServiceImp>();
            services.AddScoped<UsuarioRepository, UsuarioRepositoryImp>();
            services.AddScoped<UsuarioService, UsuarioServiceImp>();

            services.AddControllers(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Citas Medicas", Version = "v1" });
                c.CustomSchemaIds(type => type.ToString());
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}