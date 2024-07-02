using AutoMapper;
using GestorPacientes.Core.Application.Interfaces.Repositories;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.PruebaLab;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Services
{
    public class PruebaLabService : GenericService<PruebaLabViewModel,
                                                   PruebaLabSaveViewModel,
                                                   PruebaLabUpdateViewModel,
                                                   PruebaLab>,IPruebaLabService
    {
        private readonly IPruebaLabRepository _pruebaLabRepository;
        private readonly IMapper _mapper;

        public PruebaLabService(IPruebaLabRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _pruebaLabRepository = repository;
            _mapper = mapper;
        }
    }
}