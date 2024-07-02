using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.PruebaLab;
using GestorPacientes.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace GestorPacientes.Controllers
{
    public class PruebaLabController : Controller
    {
        private readonly IPruebaLabService _pruebaLabService;
        private readonly ValidateUserSession _validator;


        public PruebaLabController(IPruebaLabService pruebaLabService, 
                                   ValidateUserSession validator)
        {
            _pruebaLabService = pruebaLabService;
            _validator = validator;
        }


        public async Task<ActionResult> Index()
        {
            if (!_validator.Administrador())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _pruebaLabService.Get());
        }


        public ActionResult Create()
        {
            if (!_validator.Administrador())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View();
        }
        
        [HttpPost]        
        public async Task<ActionResult> Create(PruebaLabSaveViewModel vm)
        {
            if (!_validator.Administrador())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            try
            {
                await _pruebaLabService.Add(vm);
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

            return View(await _pruebaLabService.GetById(id));
        }
        
        [HttpPost]        
        public async Task<ActionResult> Edit(int id, PruebaLabUpdateViewModel vm)
        {
            if (!_validator.Administrador())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            try
            {
                await _pruebaLabService.Update(vm, id);
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

            return View(await _pruebaLabService.GetById(id));
        }
        
        [HttpPost]        
        public async Task<ActionResult> Delete(int id, PruebaLabUpdateViewModel vm)
        {
            if (!_validator.Administrador())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            try
            {
                await _pruebaLabService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}