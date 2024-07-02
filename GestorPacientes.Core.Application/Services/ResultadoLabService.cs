using AutoMapper;
using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Cita;
using GestorPacientes.Core.Application.ViewModels.PruebaLab;
using GestorPacientes.Core.Application.ViewModels.ResultadoLab;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Services
{
    public class ResultadoLabService : GenericService<ResultadoLabViewModel,
                                                      ResultadoLabSaveViewModel,
                                                      ResultadoLabUpdateViewModel,
                                                      ResultadoLab>, IResultadoLabService
    {
        private readonly IResultadoLabRepository _resultadoLabrepository;
        private readonly IMapper _mapper;

        public ResultadoLabService(IResultadoLabRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _resultadoLabrepository = repository;
            _mapper = mapper;
        }

        public async Task AddByCita(CitaConsultaViewModel vm)
        {
            foreach (var item in vm.PruebaLabSeleccionada)
            {
                ResultadoLabSaveViewModel resultadoLabSaveVm = new()
                {
                    CitaId = vm.CitaId,
                    PruebaLabId = item,
                    Estado = "Pendiente"
                };
                await this.Add(resultadoLabSaveVm);
            }
        }

        public async Task<List<ResultadoLabViewModel>> GetAllWithIncludeAsync() 
        {
            var listResultadoLab = await _resultadoLabrepository.GetAllWithIncludeAsync(new List<string> { "Paciente", "PruebaLab" });

            var ResultadoLabFilter = listResultadoLab.Where(r => r.Estado == "Pendiente").Select(r => new ResultadoLabViewModel
            {
                ResultadosLabId = r.ResultadosLabId,
                Estado = r.Estado,
                NombrePaciente = $"{r.Paciente.Nombre} {r.Paciente.Apellido}",
                Cedula = $"{r.Paciente.Cedula}",
                NombrePruebaLab = r.PruebaLab.NombrePruebaLab 

            });
            return ResultadoLabFilter.ToList();
        }        
    }
}