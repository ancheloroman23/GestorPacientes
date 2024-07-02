using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Insfrastructure.Persistence.Context;
using GestorPacientes.Insfrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestorPacientes.Insfrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationContext> 
                    (options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IResultadoLabRepository, ResultadoLabRepository>();
            services.AddTransient<IPruebaLabRepository, PruebaLabRepository>();
            services.AddTransient<IPacienteRepository, PacienteRepository>();
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<ICitaRepository, CitaRepository>();
        }
    }
}
