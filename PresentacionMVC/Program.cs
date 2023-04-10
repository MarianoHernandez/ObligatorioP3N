using Negocio.InterfacesRepositorio;
using Datos.Repositorios;
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
            builder.Services.AddScoped<IListadoMantenimiento, ListadoMantenimiento>();
            
            
            #region Build cabania
            builder.Services.AddScoped<IAltaCabania, AltaCabania>();
            builder.Services.AddScoped<IListadoCabania,ListadoCabania>();
            builder.Services.AddScoped<IFindById, FindById>();
            #endregion
            
            
            #region Build TipoCabania
            builder.Services.AddScoped<IAltaTipoCabania, AltaTipoCabania>();
            builder.Services.AddScoped<IListadoTipoCabania, ListadoTipoCabania>();
            builder.Services.AddScoped<IFindByName, FindByName>();
            builder.Services.AddScoped<IDeleteTipo, DeleteTipo>();
            builder.Services.AddScoped<IUpdateTipo, UpdateTipo>();

            #endregion



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
                pattern: "{controller=Cabania}/{action=Create}/{id?}");


            app.Run();
        }
    }
}