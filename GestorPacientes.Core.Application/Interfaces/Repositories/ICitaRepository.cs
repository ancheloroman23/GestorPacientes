using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Interfaces.Repositories
{
    public interface ICitaRepository : IGenericRepository<Cita>
    {
        Task<Cita> GetByIdWithAll(int id);
    }
}
