using AutoMapper;
using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Doctor;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Services
{
    public class DoctorService : GenericService<DoctorViewModel,
                                                DoctorSaveViewModel,
                                                DoctorUpdateViewModel,
                                                Doctor>,IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _doctorRepository = repository;
            _mapper = mapper;
        }              
    }
}
