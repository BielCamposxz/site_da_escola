using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using site_da_escola.Data;
using site_da_escola.Models;
using System.Web.Mvc;

namespace site_da_escola.Repositorio
{
    public class PostarEvento : IPostarEvento
    {
        private readonly BancoContext _context;

        public PostarEvento(BancoContext context)
        {
            _context = context;
        }

        public async Task CriarPostagemEvento(EventosModel postagem, IFormFile arquivo)
        {
            if (arquivo != null && arquivo.Length > 0)
            {
                using var ms = new MemoryStream();
                await arquivo.CopyToAsync(ms);

                postagem.NomeArquivo = arquivo.FileName;
                postagem.Imagem = ms.ToArray();
                postagem.ContentType = arquivo.ContentType;
                postagem.DataDePostagem = DateTime.Now;
            }

            _context.Eventos.Add(postagem);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EventosModel>> ListarEventos()
        {
            return await _context.Eventos.ToListAsync();
        }

        public int GetTotalEventos()
        {
            return _context.Eventos.Count();
        }

    }
}
