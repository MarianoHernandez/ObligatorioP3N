using Negocio.InterfacesRepositorio;
using Datos.Repositorios;
using PresentacionMVC.Controllers;
using Aplicacion.AplicacionesCabaña;
using Aplicacion.AplicacionesTipoCabaña;
using Datos.Entity;
using Microsoft.EntityFrameworkCore;
using Aplicacion.AplicacionesMantenimientos;
using Aplicacion.AplicacionesUsuario;

namespace PresentacionMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //AGREGAR INFORMACIÓN PARA LA INYECCIÓN DE DEPENDENCIAS AUTOMÁTICA:
            builder.Services.AddScoped<IRepositorioTipoCabania, RepositorioTipoCabania>();
            builder.Services.AddScoped<IRepositorioCabania, RepositorioCabania>();
            builder.Services.AddScoped<IRepositorioMantenimiento, RepositorioMantenimiento>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();


            builder.Services.AddScoped<ILoginUsuario, LoginUsuario>();
            builder.Services.AddScoped<IAltaUsuario, AltaUsuario>();
            builder.Services.AddScoped<IAltaMantenimiento, AltaMantenimiento>();
            builder.Services.AddScoped<IAltaCabania, AltaCabania>();
            builder.Services.AddScoped<IAltaTipoCabania, AltaTipoCabania>();

            builder.Services.AddScoped<IListadoMantenimiento, ListadoMantenimiento>();
            builder.Services.AddScoped<IListadoTipoCabania, ListadoTipoCabania>();

            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json", false, true);
            var configuration = configurationBuilder.Build();
            string strCon = configuration.GetConnectionString("MiConexion");

            builder.Services.AddDbContext<LibreriaContext>(options => options.UseSqlServer(strCon));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Mantenimiento}/{action=Create}/{id?}");

            app.Run();
        }
    }
}