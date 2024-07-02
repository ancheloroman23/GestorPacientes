using GestorPacientes.Core.Application.Interfaces.Services;
using GestorPacientes.Core.Application.ViewModels.Usuario;
using GestorPacientes.Core.Application.Helpers;
using GestorPacientes.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace GestorPacientes.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ValidateUserSession _validator;

        public UsuarioController(IUsuarioService usuarioService, 
                                 ValidateUserSession validator)
        {
            _usuarioService = usuarioService;
            _validator = validator;
        }

        public async Task<ActionResult> Index()
        {
            if (!_validator.Administrador())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View(await _usuarioService.Get());
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]        
        public async Task<ActionResult> Login(LoginViewModel viewModel)
        {
            try
            {
                UsuarioViewModel usuarioViewModel = await _usuarioService.Login(viewModel);

                if (usuarioViewModel != null)
                {
                    HttpContext.Session.Set<UsuarioViewModel>("usuario", usuarioViewModel);
                    return RedirectToRoute(new { controller = "Home", action = "Index" });
                }
                else
                {
                    ModelState.AddModelError("LoginValidation", "Nombre de usuario o Clave incorrecta, Favor de poner sus credenciales correcta!");
                }

                return View(viewModel);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Register()
        {
            if (!_validator.Administrador())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            return View();
        }

        [HttpPost]        
        public async Task<ActionResult> Register(UsuarioSaveViewModel vm)
        {
            if (!_validator.Administrador())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            if (ModelState.IsValid && await _usuarioService.ExistsUsername(vm))
            {
                ModelState.AddModelError("Username", "Nombre de usuario ya existe");
                return View(vm);
            }

            try
            {
                await _usuarioService.Add(vm);
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

            return View(await _usuarioService.GetById(id));
        }
        
        [HttpPost]        
        public async Task<ActionResult> Edit(int id, UsuarioUpdateViewModel vm)
        {
            if (!_validator.Administrador())
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            if (ModelState.IsValid && await _usuarioService.ExistsUsername(vm))
            {
                ModelState.AddModelError("NombreUsuario", "Nombre de usuario esta registrado");
                return View(vm);
            }

            try
            {
                await _usuarioService.Update(vm, id);
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

            return View(await _usuarioService.GetById(id));
        }
        
        [HttpPost]        
        public async Task<ActionResult> Delete(int id, UsuarioUpdateViewModel vm)
        {
            try
            {
                if (!_validator.Administrador())
                    return RedirectToRoute(new { controller = "Home", action = "Index" });

                await _usuarioService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("usuario");
            return RedirectToRoute(new { controller = "Usuario", action = "Login" });
        }
    }
}