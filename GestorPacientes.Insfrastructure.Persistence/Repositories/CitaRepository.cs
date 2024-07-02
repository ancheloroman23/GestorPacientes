using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Domain.Entities;
using GestorPacientes.Insfrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace GestorPacientes.Insfrastructure.Persistence.Repositories
{
    public class CitaRepository : GenericRepository<Cita>, ICitaRepository
    {
        private readonly ApplicationContext _dbContext;

        public CitaRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Cita> GetByIdWithAll(int id)
        {
            return await _dbContext.Citas
                                    .Include(c => c.ResultadosLabs)
                                    .ThenInclude(rl => rl.PruebaLab)
                                    .Include(c => c.Paciente)
                                    .FirstOrDefaultAsync(c => c.CitaId == id);
        }
    }
}
