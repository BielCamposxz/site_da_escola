using Microsoft.AspNetCore.Mvc;
using site_da_escola.Data;
using site_da_escola.filter;
using site_da_escola.Models;
using site_da_escola.Repositorio;

namespace site_da_escola.Controllers
{
    [PaginaRestritaParaAdmin]
    public class AdminPageController : Controller
    {
        private readonly IPostarNoticia _postarNoticia;
        private readonly IPostarEvento _postarEvento;
        private readonly BancoContext _BancoContext;
        private readonly IUsuario _usuario;


        public AdminPageController(IPostarNoticia postarNoticia, IPostarEvento postarEvento, IUsuario usuario, BancoContext bancoContext)
        {
            _postarNoticia = postarNoticia;
            _postarEvento = postarEvento;
            _usuario = usuario;
            _BancoContext = bancoContext;
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

        public IActionResult Feedback()
        {
           List<FeedbackModel> feedback = _BancoContext.Feedbacks.ToList();
            return View(feedback);
        }

        public IActionResult Apagarfeedback(int id)
        {
            FeedbackModel feedback = _BancoContext.Feedbacks.FirstOrDefault(f => f.Id == id);
            _BancoContext.Feedbacks.Remove(feedback);
            _BancoContext.SaveChanges();
            return RedirectToAction("Feedback");
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

        [HttpPost]
        public IActionResult ApagarUsuario(UsuariosModel id)
        {
            try
            {
                if(_usuario.ApagarUsuario(id.Id))
                {
                    TempData["MensagemSucesso"] = "Usuário apagado com sucesso";
                }
                else
                {
                    TempData["MessagenErro"] = "Ops, Algo deu errado";
                }
                return RedirectToAction("Usuarios");
            }
            catch (Exception err)
            {
                TempData["MessagenErro"] = $"Ops, algo deu errado: {err.Message}";
                return RedirectToAction("Usuarios");
            }
        }

        [HttpPost]
        public IActionResult EditarUsuario(UsuariosModel usuario)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    UsuariosModel usuarioIsTrue = _usuario.BuscarUsuarioPorId(usuario.Id);
                    if(usuarioIsTrue == null)
                    {
                        TempData["MensagenErro"] = "O usuario nao existe";
                        return RedirectToAction("Usuarios");
                    }

                    _usuario.Editar(usuario);
                    return RedirectToAction("Usuarios");

                }

                return View("Usuarios", usuario);
            }
            catch (Exception err)
            {
                TempData["MessagenErro"] = $"Ops, algo deu errado: {err.Message}" ;
                return RedirectToAction("Usuarios");
            }
        }

        public List<UsuariosModel> BuscarTodosUsuario()
        {
            return _usuario.BuscarTodosUsuario();
        }

        public IActionResult PostarEventos()
        {
            return View();
        }

        public IActionResult EditarUsuario(int id)
        {
            UsuariosModel usuario = _usuario.BuscarUsuarioPorId(id);
            return View(usuario);
        }

        public IActionResult ApagarUsuario(int id)
        {
            UsuariosModel usuario = _usuario.BuscarUsuarioPorId(id);
            return View(usuario);
        }

        public IActionResult Usuarios()
        {
            List<UsuariosModel> usuarios = BuscarTodosUsuario();
            return View(usuarios);
        }

        public IActionResult PostarNoticia()
        {
            return View();
        }
    }
}
