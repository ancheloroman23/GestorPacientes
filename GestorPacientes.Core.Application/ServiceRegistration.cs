using GestorPacientes.Core.Application.Helpers;
using GestorPacientes.Core.Application.Interfaces.Helpers;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GestorPacientes.Core.Application
{
    public static class ServiceRegistration
    {

        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());                     

            #region Services
            services.AddTransient(typeof(IGenericService<,,,>), typeof(GenericService<,,,>));
            services.AddTransient<IUsuarioService, UsuarioService>();
            services.AddTransient<IResultadoLabService, ResultadoLabService>();
            services.AddTransient<IPruebaLabService, PruebaLabService>();
            services.AddTransient<IPacienteService, PacienteService>();
            services.AddTransient<IDoctorService, DoctorService>();
            services.AddTransient<ICitaService, CitaService>();
            #endregion

            #region Helper
            services.AddTransient<IFileManager, FileManager>();
            #endregion  
        }
    }
}
