    using Microsoft.AspNetCore.Mvc;
using site_da_escola.Data;
using site_da_escola.Models;
using site_da_escola.Repositorio;

namespace site_da_escola.Controllers
{
    public class AdminPageController : Controller
    {
        private readonly IPostarNoticia _postarNoticia;
        private readonly IPostarEvento _postarEvento;
        private readonly IUsuario _usuario;


        public AdminPageController(IPostarNoticia postarNoticia, IPostarEvento postarEvento, IUsuario usuario)
        {
            _postarNoticia = postarNoticia;
            _postarEvento = postarEvento;
            _usuario = usuario;

        }

        public IActionResult Index()
        {

            var dashboard = new DashboardViewModel
            {
                TotalEventos = _postarEvento.GetTotalEventos(),
                TotalNoticias = _postarNoticia.GetTotalNoticias(),
                TotalUsuarios = _usuario.GetTotalUsuarios()

            };

            return View(dashboard);

        }

       
        [HttpPost]
        public async Task<IActionResult> CriarNoticia(NoticiasModel postagem, IFormFile arquivo)
        {
            if (!ModelState.IsValid)
            {
                return View(postagem);
            }

            await _postarNoticia.CriarPostagemNoticia(postagem, arquivo);
            TempData["MensagemSucesso"] = "Postagem enviada com sucesso!";
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> CriarEvento(EventosModel postagem, IFormFile arquivo)
        {
            if (!ModelState.IsValid)
            {
                return View(postagem);
            }

            await _postarEvento.CriarPostagemEvento(postagem, arquivo);
            TempData["MensagemSucesso"] = "Postagem enviada com sucesso!";
            return RedirectToAction("Index", "Home");
        }

        public IActionResult PostarEventos()
        {
            return View();
        }

        public IActionResult Usuarios()
        {
            return View();
        }

        public IActionResult PostarNoticia()
        {
            return View();
        }
    }
}
