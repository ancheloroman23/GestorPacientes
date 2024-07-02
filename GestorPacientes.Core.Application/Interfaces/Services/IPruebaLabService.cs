using GestorPacientes.Core.Application.ViewModels.PruebaLab;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Interfaces.Services
{
    public interface IPruebaLabService : IGenericService<PruebaLabViewModel,
                                                         PruebaLabSaveViewModel,
                                                         PruebaLabUpdateViewModel,
                                                         PruebaLab>
    {
    }
}
