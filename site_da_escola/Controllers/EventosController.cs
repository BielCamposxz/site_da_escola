using Microsoft.AspNetCore.Mvc;
using site_da_escola.Data;
using site_da_escola.filter;
using site_da_escola.Helper;
using site_da_escola.Migrations;
using site_da_escola.Models;
using site_da_escola.Repositorio;
using site_da_escola.Repositorio.Fixados;

namespace site_da_escola.Controllers
{
    public class EventosController : Controller
    {
        private readonly IPostarEvento _eventoRepositorio;
        private readonly ISessao _sessao;
        private readonly IFixadosEventos _fixados;
        private readonly BancoContext _Context;

        public EventosController(IPostarEvento eventoRepositorio, IFixadosEventos fixados, BancoContext bancoContext, ISessao sessao)
        {
            _eventoRepositorio = eventoRepositorio;
            _fixados = fixados;
            _Context = bancoContext;
            _sessao = sessao;
        }

        [PaginaRestritaParaAdmin]
        public IActionResult Excluir(int id)
        {
            EventosModel evento = _Context.Eventos.FirstOrDefault(ev => ev.Id == id);
            _Context.Eventos.Remove(evento);


            FixadosModel fixadosId = _Context.Fixados.FirstOrDefault(ev => ev.Id_Estrangeiro == id && ev.Tipo == "Eventos");
            if(fixadosId  != null)
            {
                _Context.Fixados.Remove(fixadosId);
            }


            _Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Index()
        {
            var eventos = await _eventoRepositorio.ListarEventos();
            UsuariosModel usuario = _sessao.BuscarSessaoDoUsuario();


            var model = new EventoUsuarioModel
            {
                usuario = usuario,
                TotalEventos = eventos
            };

            return View(model);
        }

        [PaginaRestritaParaAdmin]
        public IActionResult CriarFixado(int id)
        {
            FixadosModel fixadosId = _Context.Fixados.FirstOrDefault(ev => ev.Id_Estrangeiro == id && ev.Tipo == "Eventos");
            if(fixadosId != null)
            {
                TempData["MensagemErro"] = "Voce ja fixou evento";
                return RedirectToAction("Index", "Home");
            }else
            {
                _fixados.EnviarFixado(id); 
                return RedirectToAction("Index", "Home");

            }
        }


        public async Task<IActionResult> Imagem(int id)
        {
            var eventos = await _eventoRepositorio.ListarEventos();
            var evento = eventos.FirstOrDefault(e => e.Id == id);

            if (evento == null || evento.Imagem == null || evento.Imagem.Length == 0)
                return NotFound();

            return File(evento.Imagem, evento.ContentType);
        }
    }
}
