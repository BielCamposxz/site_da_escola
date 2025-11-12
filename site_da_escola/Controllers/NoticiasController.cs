using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using site_da_escola.Data;
using site_da_escola.filter;
using site_da_escola.Helper;
using site_da_escola.Migrations;
using site_da_escola.Models;
using site_da_escola.Repositorio;
using site_da_escola.Repositorio.Fixados;

namespace site_da_escola.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly IPostarNoticia _eventoRepositorio;
        private readonly IFixadosNoticias _fixadoNoticia;
        private readonly ISessao _sessao;
        private readonly BancoContext _Context;

        public NoticiasController(IPostarNoticia eventoRepositorio, IFixadosNoticias fixados, BancoContext bancoContext, ISessao sessao)
        {
            _eventoRepositorio = eventoRepositorio;
            _fixadoNoticia = fixados;
            _Context = bancoContext;
            _sessao = sessao;
        }

        public IActionResult Excluir(int id)
        {
            NoticiasModel noticias = _Context.Noticias.FirstOrDefault(ev => ev.Id == id);
            _Context.Noticias.Remove(noticias);


            FixadosModel fixadosId = _Context.Fixados.FirstOrDefault(ev => ev.Id_Estrangeiro == noticias.Id && ev.Tipo == "Noticia");
            if (fixadosId != null)
            {
                _Context.Fixados.Remove(fixadosId);
            }


            _Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Index()
        {
            var eventos = await _eventoRepositorio.ListarEventos();
            UsuariosModel usuarioSessao = _sessao.BuscarSessaoDoUsuario();

            var model = new NoticiaUsuarioModel
            {
                usuario = usuarioSessao,
                NoticiasTotal = eventos
            };
            return View(model);
        }

        [PaginaRestritaParaAdmin]
        public IActionResult CriarFixado(int id)
        {
            FixadosModel fixadosId = _Context.Fixados.FirstOrDefault(ev => ev.Id_Estrangeiro == id && ev.Tipo == "Noticias");
            if (fixadosId != null)
            {
                TempData["MensagemErro"] = "Voce ja fixou essa noticia";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                _fixadoNoticia.EnviarFixado(id);
                return RedirectToAction("Index", "Home");

            }
        }

        public async Task<IActionResult> Imagem(int id)
        {
            var eventos = await _eventoRepositorio.ListarEventos();
            var evento = eventos.FirstOrDefault(e => e.Id == id);

            if (evento?.Imagem == null)
                return NotFound();

            return File(evento.Imagem, evento.ContentType);
        }
    }
}
