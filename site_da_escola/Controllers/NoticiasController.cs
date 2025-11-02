using Microsoft.AspNetCore.Mvc;
using site_da_escola.Repositorio;

namespace site_da_escola.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly IPostarNoticia _eventoRepositorio;

        public NoticiasController(IPostarNoticia eventoRepositorio)
        {
            _eventoRepositorio = eventoRepositorio;
        }

        // 🔹 Método para exibir a página
        public async Task<IActionResult> Index()
        {
            var eventos = await _eventoRepositorio.ListarEventos();
            return View(eventos);
        }

        // 🔹 Método para retornar imagem
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
