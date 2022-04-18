using FinanciamentoData.Data;
using FinanciamentoInterface.Repositorio;
using FinanciamentoInterface.Service;
using FinanciamentoRepositorio.Repositorio;
using FinanciamentoService;
using FinanciamentoService.IServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Refit;
using System;

namespace FinanciamentoAPI
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
            // Conexão com banco de dados
            services.AddDbContext<DataContext>(options => 
                     options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Injeção de dependência
            services.AddScoped<IImovelRepositorio, ImovelRepositorio>();
            services.AddScoped<IProponenteRepositorio, ProponenteRepositorio>();
            services.AddScoped<IPropostaRepositorio, PropostaRepositorio>();

            services.AddScoped<IImovelService, ImovelService>();
            services.AddScoped<IProponenteService, ProponenteService>();
            services.AddScoped<IPropostaService, PropostaService>();

            services.AddRefitClient<ICepService>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("http://localhost:44358");
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FinanciamentoAPI", Version = "v1" });
            });

            //Singleton padrão unico
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinanciamentoAPI v1"));
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
