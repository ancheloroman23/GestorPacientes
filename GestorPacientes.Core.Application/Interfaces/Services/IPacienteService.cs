using GestorPacientes.Core.Application.ViewModels.Paciente;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Interfaces.Services
{
    public interface IPacienteService : IGenericService<PacienteViewModel,
                                                        PacienteSaveViewModel,
                                                        PacienteUpdateViewModel,
                                                        Paciente>
    {
    }
}
