using GestorPacientes.Core.Application.Interfaces.Helpers;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Doctor;
using GestorPacientes.Core.Application.ViewModels.Paciente;
using GestorPacientes.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace GestorPacientes.Controllers
{
    public class PacienteController : Controller
    {
        #region Dependencies
        private readonly IPacienteService _pacienteService;
        private readonly IFileManager _fileManager;
        private readonly ValidateUserSession _validator;
        #endregion

        public PacienteController(IPacienteService pacienteService,
                                  IFileManager fileManager,
                                  ValidateUserSession validator)
        {
            _pacienteService = pacienteService;
            _fileManager = fileManager;
            _validator = validator;
        }

        public async Task<ActionResult> Index()
        {
            if (!_validator.Asistente())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _pacienteService.Get());
        }

        public ActionResult Create()
        {
            if (!_validator.Asistente())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            PacienteSaveViewModel vm = new();

            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Create(PacienteSaveViewModel vm)
        {
            if (!_validator.Asistente())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            try
            {
                vm.Foto = await _fileManager.Save(vm.Imagen, "patiente");
                await _pacienteService.Add(vm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        public async Task<ActionResult> Edit(int id)
        {
            if (!_validator.Asistente())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _pacienteService.GetById(id));
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, PacienteUpdateViewModel vm)
        {
            if (!_validator.Asistente())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            try
            {
                if (vm.Imagen != null)
                    vm.Foto = await _fileManager.Update(vm.Imagen, "patiente", vm.Foto);

                await _pacienteService.Update(vm, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
        public async Task<ActionResult> Delete(int id)
        {
            if (!_validator.Asistente())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _pacienteService.GetById(id));
        }
        
        [HttpPost]        
        public async Task<ActionResult> Delete(int id, PacienteUpdateViewModel vm)
        {
            if (!_validator.Asistente())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            try
            {
                vm = await _pacienteService.GetById(id);

                if (vm.Foto != null)
                    _fileManager.Delete("patiente", vm.Foto);

                await _pacienteService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}