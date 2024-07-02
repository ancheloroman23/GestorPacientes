using GestorPacientes.Core.Application.Interfaces.Helpers;
using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Doctor;
using GestorPacientes.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace GestorPacientes.Controllers
{
    public class DoctorController : Controller
    {
        #region Dependencies
        private readonly IDoctorService _doctorService;
        private readonly IFileManager _fileManager;
        private readonly ValidateUserSession _validator;
        #endregion       

        public DoctorController(IDoctorService doctorService, 
                                IFileManager fileManager, 
                                ValidateUserSession validator)
        {
            _doctorService = doctorService;
            _fileManager = fileManager;
            _validator = validator;
        }

        public async Task<ActionResult> Index()
        {
            if (!_validator.Administrador())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _doctorService.Get());
        }

        public ActionResult Create()
        {
            if (!_validator.Administrador())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            DoctorSaveViewModel vm = new();

            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Create(DoctorSaveViewModel vm)
        {
            if (!_validator.Administrador())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            try
            {
                vm.Foto = await _fileManager.Save(vm.Imagen, "doctores");
                await _doctorService.Add(vm);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            if (!_validator.Administrador())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _doctorService.GetById(id));
        }
        
        [HttpPost]        
        public async Task<ActionResult> Edit(int id, DoctorUpdateViewModel vm)
        {
            if (!_validator.Administrador())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            try
            {
                if (vm.Imagen != null)
                    vm.Foto = await _fileManager.Update(vm.Imagen, "usuario", vm.Foto);

                await _doctorService.Update(vm, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            if (!_validator.Administrador())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _doctorService.GetById(id));
        }
        
        [HttpPost]        
        public async Task<ActionResult> Delete(int id, DoctorUpdateViewModel vm)
        {
            if (!_validator.Administrador())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            try
            {
                vm = await _doctorService.GetById(id);

                if (vm.Foto != null)
                    _fileManager.Delete("doctores", vm.Foto);

                await _doctorService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}