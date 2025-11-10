using Microsoft.AspNetCore.Mvc;
using site_da_escola.Data;

namespace site_da_escola.Controllers
{
    public class FixadosController : Controller
    {
        private readonly BancoContext _bancoContext;

        public FixadosController(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public IActionResult Imagem(int id)
        {
            var fixado = _bancoContext.Fixados.FirstOrDefault(f => f.Id == id);
            
            if (fixado.Imagem != null && fixado.Imagem.Length > 0)
                return File(fixado.Imagem, fixado.ContentType);

            if (fixado.Tipo == "Evento")
            {
                var evento = _bancoContext.Eventos.FirstOrDefault(e => e.Id == fixado.Id_Estrangeiro);
                if (evento != null && evento.Imagem != null)
                    return File(evento.Imagem, evento.ContentType);
            }
            else if (fixado.Tipo == "Noticia")
            {
                var noticia = _bancoContext.Noticias.FirstOrDefault(n => n.Id == fixado.Id_Estrangeiro);
                if (noticia != null && noticia.Imagem != null)
                    return File(noticia.Imagem, noticia.ContentType);
            }


            return RedirectToAction("Index");
        }
    }
}
