using GestorPacientes.Core.Application.ViewModels.Cita;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Interfaces.Services
{
    public interface ICitaService : IGenericService<CitaViewModel,
                                                    CitaSaveViewModel,
                                                    CitaUpdateViewModel,
                                                    Cita>
    {
        Task EstadoUpdate(int id, int state);
        Task<CitaViewModel> GetByIdWithAll(int id);
    }
}
