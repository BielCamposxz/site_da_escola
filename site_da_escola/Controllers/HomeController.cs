using Microsoft.AspNetCore.Mvc;
using site_da_escola.Data;
using site_da_escola.filter;
using site_da_escola.Helper;
using site_da_escola.Models;
using site_da_escola.Repositorio;
using site_da_escola.Repositorio.Fixados;
using System.Diagnostics;

namespace site_da_escola.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsuario _usuario;
        private readonly ISessao _sessao;
        private readonly IFixadosEventos _fixadosRepositorio;
        private readonly BancoContext _bancoContext;

        public HomeController(IUsuario usuario, ISessao sessao, IFixadosEventos fixadosRepositorio, BancoContext bancoContext)
        {
            _usuario = usuario;
            _sessao = sessao;
            _fixadosRepositorio = fixadosRepositorio;
            _bancoContext = bancoContext;
        }

        public IActionResult RegistrarUsuario(UsuariosModel usuario)
        {
            _sessao.CriarSessaoDoUsuario(usuario);
            _usuario.Registrar(usuario);
            return RedirectToAction("Index");
        }

        public IActionResult Login() => View();

        public IActionResult Cadrastro() => View();

        [PaginaRestritaParaAdmin]
        public IActionResult DesfixarFixado(int id)
        {
            FixadosModel fixado = _bancoContext.Fixados.FirstOrDefault(fix => fix.Id == id);
            _bancoContext.Fixados.Remove(fixado);
            _bancoContext.SaveChanges();
            return RedirectToAction("Index"); 
        }

        [HttpPost]
        public IActionResult Login(UsuarioSemNomeModel usuario)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    UsuariosModel UsuarioRetornado = _usuario.BuscarUsuarioPorEmail(usuario.Email);

                    if (UsuarioRetornado != null)
                    {
                        if (UsuarioRetornado.ValidarSenha(usuario.Senha))
                        {
                            _sessao.CriarSessaoDoUsuario(UsuarioRetornado);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = "Senha inválida";
                        return View(usuario);
                    }

                    TempData["MensagemErro"] = "Usuário e/ou senha inválidos";
                    return View(usuario);
                }
                return View(usuario);
            }
            catch (Exception err)
            {
                TempData["MensagemErro"] = $"Ops, algo deu errado {err}";
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Index()
        {
            UsuariosModel usuario = _sessao.BuscarSessaoDoUsuario();

            var fixados = _fixadosRepositorio.GetTodosFixados();

            var model = new FixadosUsuarioModel
            {
                usuario = usuario,
                FixadosTotal = fixados
            };

            int total = _bancoContext.Fixados.Count();

            if(total > 3)
            {
                var eventoMaisAntigo = _bancoContext.Fixados
                    .OrderBy(e => e.Id)
                    .FirstOrDefault();
                _bancoContext.Fixados.Remove(eventoMaisAntigo);
                _bancoContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [PaginaRestritaParaUserNaoLogado]
        public IActionResult Sair()
        {
            _sessao.ApagarSessaoUsuario();
            return RedirectToAction("Index", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
