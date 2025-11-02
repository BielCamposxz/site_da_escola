using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using site_da_escola.Models;
using site_da_escola.Repositorio;

namespace site_da_escola.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsuario _usuario;

        public HomeController(IUsuario usuario)
        {
                _usuario = usuario;
        }
        public IActionResult RegistrarUsuario(UsuariosModel usuario)
        {
            _usuario.Registrar(usuario);
            return View("Index");
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Cadrastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UsuariosModel usuario)
        {
            UsuariosModel UsuarioRetornado = _usuario.BuscarUsuarioPorEmail(usuario);
            if (UsuarioRetornado != null)
            {
                if (UsuarioRetornado.ValidarSenha(usuario.Senha))
                {
                    return RedirectToAction("Index", "AdminPage");
                }
              
                    
                    TempData["MensagemErro"] = "Senha inválida";
                    return View(usuario);

            }
            TempData["MensagemErro"] = "Usuário e/ou senha inválidos";

            return View(usuario);
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
