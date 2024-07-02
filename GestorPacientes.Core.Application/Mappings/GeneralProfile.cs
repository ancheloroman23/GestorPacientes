using AutoMapper;
using GestorPacientes.Core.Application.ViewModels.Cita;
using GestorPacientes.Core.Application.ViewModels.Doctor;
using GestorPacientes.Core.Application.ViewModels.Paciente;
using GestorPacientes.Core.Application.ViewModels.PruebaLab;
using GestorPacientes.Core.Application.ViewModels.ResultadoLab;
using GestorPacientes.Core.Application.ViewModels.Usuario;
using GestorPacientes.Core.Domain.Entities;

namespace GestorPacientes.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile() 
        {
            #region UsuarioProfile
            CreateMap<Usuario, UsuarioSaveViewModel>()
                .ForMember(x => x.ConfirmarClave, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.UsuarioId, opt => opt.Ignore());

            CreateMap<Usuario, UsuarioUpdateViewModel>()
                .ForMember(dest => dest.ConfirmarClave, opt => opt.MapFrom(src => src.Clave))
                .ReverseMap();

            CreateMap<Usuario, ViewModels.Usuario.UsuarioViewModel>()
                .ReverseMap();
            #endregion

            #region ResultadoLabProfile
            CreateMap<ResultadoLab, ResultadoLabSaveViewModel>()
                .ForMember(x => x.Resultado, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.ResultadosLabId, opt => opt.Ignore())
                .ForMember(x => x.PruebaLab, opt => opt.Ignore())
                .ForMember(x => x.Cita, opt => opt.Ignore());

            CreateMap<ResultadoLab, ResultadoLabUpdateViewModel>()
                .ReverseMap()
                .ForMember(x => x.Cita, opt => opt.Ignore())
                .ForMember(x => x.PruebaLab, opt => opt.Ignore());

            CreateMap<ResultadoLab, ViewModels.ResultadoLab.ResultadoLabViewModel>()
                .ReverseMap();
            #endregion

            #region PruebaLabProfile
            CreateMap<PruebaLab, PruebaLabSaveViewModel>()
                .ReverseMap()
                .ForMember(x => x.PruebaLabId, opt => opt.Ignore())
                .ForMember(x => x.ResultadosLabs, opt => opt.Ignore());

            CreateMap<PruebaLab, PruebaLabUpdateViewModel>()
                .ReverseMap()
                .ForMember(x => x.ResultadosLabs, opt => opt.Ignore());

            CreateMap<PruebaLab, ViewModels.PruebaLab.PruebaLabViewModel>()
                .ReverseMap();
            #endregion

            #region PacienteProfile
            CreateMap<Paciente, PacienteSaveViewModel>()
                .ForMember(x => x.Imagen, opt => opt.Ignore())
            .ReverseMap()
                .ForMember(x => x.PacienteId, opt => opt.Ignore())
                .ForMember(x => x.Citas, opt => opt.Ignore());

            CreateMap<Paciente, PacienteUpdateViewModel>()
            .ForMember(x => x.Imagen, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.Citas, opt => opt.Ignore());

            CreateMap<Paciente, ViewModels.Paciente.PacienteViewModel>()
                .ReverseMap();
            #endregion

            #region DoctorProfile
            CreateMap<Doctor, DoctorSaveViewModel>()
                .ForMember(x => x.Imagen, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(x => x.DoctorId, opt => opt.Ignore())
                .ForMember(x => x.Citas, opt => opt.Ignore());

            CreateMap<Doctor, DoctorUpdateViewModel>()
                .ForMember(x => x.Imagen, opt => opt.Ignore())
                .ReverseMap()
            .ForMember(x => x.Citas, opt => opt.Ignore());

            CreateMap<Doctor, ViewModels.Doctor.DoctorViewModel>()
                .ReverseMap();
            #endregion

            #region CitaProfile
            CreateMap<Cita, CitaSaveViewModel>()
                .ReverseMap()
                .ForMember(x => x.CitaId, opt => opt.Ignore())
                .ForMember(x => x.Doctor, opt => opt.Ignore())
                .ForMember(x => x.Paciente, opt => opt.Ignore())
                .ForMember(x => x.ResultadosLabs, opt => opt.Ignore());

            CreateMap<Cita, CitaUpdateViewModel>()
                .ReverseMap()
                .ForMember(x => x.Doctor, opt => opt.Ignore())
                .ForMember(x => x.Paciente, opt => opt.Ignore())
                .ForMember(x => x.ResultadosLabs, opt => opt.Ignore());

            CreateMap<Cita, ViewModels.Cita.CitaViewModel>()
                .ReverseMap();
            #endregion
        }
    }
}