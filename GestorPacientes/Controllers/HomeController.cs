using GestorPacientes.Middlewares;
using GestorPacientes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GestorPacientes.Controllers
{
    public class HomeController : Controller
    {
        #region Dependencies
        private readonly ILogger<HomeController> _logger;
        private readonly ValidateUserSession _validator;
        #endregion


        public HomeController(ILogger<HomeController> logger, 
                              ValidateUserSession validator)
        {
            _logger = logger;
            _validator = validator;
        }

        public IActionResult Index()
        {
            if (!_validator.HasUser())
                return RedirectToRoute(new { controller = "Usuario", action = "Login" });

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
