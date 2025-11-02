using Microsoft.AspNetCore.Mvc;
using site_da_escola.Repositorio;

namespace site_da_escola.Controllers
{
    public class EventosController : Controller
    {
        private readonly IPostarEvento _eventoRepositorio;

        public EventosController(IPostarEvento eventoRepositorio)
        {
            _eventoRepositorio = eventoRepositorio;
        }

        public async Task<IActionResult> Index()
        {
            var eventos = await _eventoRepositorio.ListarEventos();
            return View(eventos);
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
