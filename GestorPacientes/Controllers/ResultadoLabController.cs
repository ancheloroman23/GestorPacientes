using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.ResultadoLab;
using GestorPacientes.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace GestorPacientes.Controllers
{
    public class ResultadoLabController : Controller
    {
        #region Dependecies
        private readonly IResultadoLabService _resultadoLabService;
        private readonly ValidateUserSession _validator;
        #endregion        

        public ResultadoLabController(IResultadoLabService resultadoLabService, 
                                      ValidateUserSession validator)
        {
            _resultadoLabService = resultadoLabService;
            _validator = validator;
        }

        public async Task<IActionResult> Index()
        {
            if (!_validator.Asistente())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _resultadoLabService.GetAllWithIncludeAsync());
        }


        public async Task<ActionResult> Result(int id)
        {
            if (!_validator.Asistente())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _resultadoLabService.GetById(id));
        }

        [HttpPost]        
        public async Task<ActionResult> Result(int id, ResultadoLabUpdateViewModel vm)
        {
            try
            {
                if (!_validator.Asistente())
                    return RedirectToRoute(new { controller = "Home", action = "Index" });

                await _resultadoLabService.Update(vm, id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}