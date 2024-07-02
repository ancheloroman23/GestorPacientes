using AutoMapper;
using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Cita;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Services
{
    public class CitaService : GenericService<CitaViewModel,
                                              CitaSaveViewModel,
                                              CitaUpdateViewModel,
                                              Cita>,ICitaService
    {
        private readonly ICitaRepository _citaRepository;
        private readonly IMapper _mapper;

        public CitaService(ICitaRepository repository, IMapper mapper) : base (repository, mapper)
        {
            _citaRepository = repository;
            _mapper = mapper;
        }        

        public async Task EstadoUpdate(int id, int state)
        {
            var entity = await this.GetById(id);
            switch (state)
            {
                case 1:
                    entity.EstadoCita = "Resultado";
                    break;
                case 2:
                    entity.EstadoCita = "Finalizado";
                    break;
                default:
                    entity.EstadoCita = "Consulta";
                    break;

            }

            await this.Update(entity, id);
        }

        public async Task<CitaViewModel> GetByIdWithAll(int id)
        {
            var entity = await _citaRepository.GetByIdWithAll(id);
            CitaViewModel viewModel = _mapper.Map<CitaViewModel>(entity);
            return viewModel;
        }     
    }
}
