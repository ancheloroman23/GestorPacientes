using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Cita;
using GestorPacientes.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace GestorPacientes.Controllers
{
    public class CitaController : Controller
    {
        #region Dependencies
        private readonly IResultadoLabService _resultadoLabService;
        private readonly IPruebaLabService _pruebaLabService;
        private readonly ICitaService _citaService;
        private readonly IDoctorService _doctorService;
        private readonly IPacienteService _pacienteService;
        private readonly ValidateUserSession _validator;
        #endregion

        public CitaController(IResultadoLabService resultadoLabService, 
                              IPruebaLabService pruebaLabService, 
                              ICitaService citaService, 
                              IDoctorService doctorService, 
                              IPacienteService pacienteService, 
                              ValidateUserSession validateUserSession)
        {
            _resultadoLabService = resultadoLabService;
            _pruebaLabService = pruebaLabService;
            _citaService = citaService;
            _doctorService = doctorService;
            _pacienteService = pacienteService;
            _validator = validateUserSession;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validator.Asistente())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _citaService.GetWithAll());
        }

        public async Task<ActionResult> Create()
        {
            if (!_validator.Asistente())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            CitaSaveViewModel vm = new()
            {
                Pacientes = await _pacienteService.Get(),
                Doctores = await _doctorService.Get()            
            };

            return View(vm);
        }

        [HttpPost]        
        public async Task<ActionResult> Create(CitaSaveViewModel vm)
        {
            if (!_validator.Asistente())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            try
            {
                await _citaService.Add(vm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Consult(int id)
        {
            if (!_validator.Asistente())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            CitaConsultaViewModel vm = new()
            {
                CitaId = id,
                PruebaLabs = await _pruebaLabService.Get()
            };
            return View(vm);
        }

        [HttpPost]        
        public async Task<ActionResult> Consult(CitaConsultaViewModel vm)
        {
            if (!_validator.Asistente())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            try
            {
                await _resultadoLabService.AddByCita(vm);
                await _citaService.EstadoUpdate(vm.CitaId, 1);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Check(int id)
        {
            if (!_validator.Asistente())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _citaService.GetByIdWithAll(id));
        }

        [HttpPost]        
        public async Task<ActionResult> Check(CitaViewModel vm)
        {
            if (!_validator.Asistente())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            try
            {
                await _citaService.EstadoUpdate(vm.CitaId, 2);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Results(int id)
        {
            if (!_validator.Asistente())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _citaService.GetByIdWithAll(id));
        }

        public async Task<ActionResult> Delete(int id)
        {
            if (!_validator.Asistente())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _citaService.GetByIdWithAll(id));
        }

        [HttpPost]        
        public async Task<ActionResult> Delete(int id, CitaViewModel vm)
        {
            try
            {
                if (!_validator.Asistente())
                    return RedirectToRoute(new { controller = "Home", action = "Index" });

                await _citaService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}