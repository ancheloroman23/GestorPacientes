using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Domain.Entities;
using GestorPacientes.Insfrastructure.Persistence.Context;

namespace GestorPacientes.Insfrastructure.Persistence.Repositories
{
    public class PruebaLabRepository : GenericRepository<PruebaLab>, IPruebaLabRepository
    {
        private readonly ApplicationContext _dbContext;

        public PruebaLabRepository(ApplicationContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }
    }
}
