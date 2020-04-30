using AvaliacaoTecnica_EdersonOliveira.Filters;
using Dominio.Interfaces.Data;
using Dominio.Interfaces.Services.Anuncios;
using Dominio.Interfaces.Services.Marcas;
using Dominio.Interfaces.Services.Modelos;
using Dominio.Interfaces.Services.Relatorios;
using Dominio.Services.Anuncios;
using Dominio.Services.Marcas;
using Dominio.Services.Modelos;
using Dominio.Services.Relatorios;
using Infra.Contexto;
using Infra.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

namespace AvaliacaoTecnica_EdersonOliveira
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(typeof(UnitOfWorkFilter));
            }).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            }); 

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
           
            services.AddScoped(typeof(IListarMarcaService), typeof(ListarMarcaService));
            services.AddScoped(typeof(IObterMarcaService), typeof(ObterMarcaService));
            services.AddScoped(typeof(IAdicionarMarcaService), typeof(AdicionarMarcaService));
            services.AddScoped(typeof(IAlterarMarcaService), typeof(AlterarMarcaService));
            services.AddScoped(typeof(IDeletarMarcaService), typeof(DeletarMarcaService));

            services.AddScoped(typeof(IListarModelosService), typeof(ListarModelosService));
            services.AddScoped(typeof(IObterModeloService), typeof(ObterModeloService));
            services.AddScoped(typeof(IAdicionarModeloService), typeof(AdicionarModeloService));
            services.AddScoped(typeof(IAlterarModeloService), typeof(AlterarModeloService));
            services.AddScoped(typeof(IDeletarModeloService), typeof(DeletarModeloService));

            services.AddScoped(typeof(IAdicionarAnuncioService), typeof(AdicionarAnuncioService));
            services.AddScoped(typeof(IListarAnuncioService), typeof(ListarAnuncioService));
            services.AddScoped(typeof(IDeletarAnuncioService), typeof(DeletarAnuncioService));
            services.AddScoped(typeof(IObterAnuncioService), typeof(ObterAnuncioService));
            services.AddScoped(typeof(IAlterarAnuncioService), typeof(AlterarAnuncioService));

            services.AddScoped(typeof(IRelatorioDeVendaService), typeof(RelatorioDeVendaService));

            services.AddSwaggerDocument();

            services.AddDbContext<AvaliacaoContexto>(options => options.UseLazyLoadingProxies()
            .UseSqlServer(Configuration.GetConnectionString("AvaliacaoContext")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            UpdateDatabase(app);

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();

            using var context = serviceScope.ServiceProvider.GetService<AvaliacaoContexto>();
            context.Database.Migrate();
        }
    }
}
