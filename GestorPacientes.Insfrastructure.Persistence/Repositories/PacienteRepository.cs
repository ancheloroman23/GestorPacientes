using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Domain.Entities;
using GestorPacientes.Insfrastructure.Persistence.Context;

namespace GestorPacientes.Insfrastructure.Persistence.Repositories
{
    public class PacienteRepository : GenericRepository<Paciente>, IPacienteRepository
    {
        private readonly ApplicationContext _dbContext;

        public PacienteRepository(ApplicationContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }        
    }
}
