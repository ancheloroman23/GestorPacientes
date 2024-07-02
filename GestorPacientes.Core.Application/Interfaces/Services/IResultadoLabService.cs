using GestorPacientes.Core.Application.ViewModels.Cita;
using GestorPacientes.Core.Application.ViewModels.ResultadoLab;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Interfaces.Services
{
    public interface IResultadoLabService : IGenericService<ResultadoLabViewModel,
                                                            ResultadoLabSaveViewModel,
                                                            ResultadoLabUpdateViewModel,
                                                            ResultadoLab>
    {
        Task AddByCita(CitaConsultaViewModel vm);

        Task<List<ResultadoLabViewModel>> GetAllWithIncludeAsync();
    }
}
