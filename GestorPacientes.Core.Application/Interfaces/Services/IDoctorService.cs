using GestorPacientes.Core.Application.ViewModels.Doctor;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Interfaces.Services
{
    public interface IDoctorService : IGenericService<DoctorViewModel,
                                                      DoctorSaveViewModel,
                                                      DoctorUpdateViewModel,
                                                      Doctor>
    {
    }
}
