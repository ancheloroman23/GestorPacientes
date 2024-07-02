using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Domain.Entities;
using GestorPacientes.Insfrastructure.Persistence.Context;

namespace GestorPacientes.Insfrastructure.Persistence.Repositories
{
    public class ResultadoLabRepository : GenericRepository<ResultadoLab>, IResultadoLabRepository
    {
        private readonly ApplicationContext _dbContext;

        public ResultadoLabRepository(ApplicationContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }
    }
}
