using AutoMapper;
using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Paciente;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Services
{
    public class PacienteService : GenericService<PacienteViewModel,
                                                  PacienteSaveViewModel,
                                                  PacienteUpdateViewModel,
                                                  Paciente>,IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;

        public PacienteService(IPacienteRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _pacienteRepository = repository;
            _mapper = mapper;
        }
    }
}