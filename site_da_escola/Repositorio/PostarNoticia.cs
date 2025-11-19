using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using site_da_escola.Data;
using site_da_escola.Models;
using System.Web.Mvc;

namespace site_da_escola.Repositorio
{
    public class PostarNoticia : IPostarNoticia
    {
        private readonly BancoContext _context;

        public PostarNoticia(BancoContext context)
        {
            _context = context;
        }

        public async Task CriarPostagemNoticia(NoticiasModel postagem, IFormFile arquivo)
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

            _context.Noticias.Add(postagem);
            await _context.SaveChangesAsync();
        }

        public async Task<List<NoticiasModel>> ListarEventos()
        {
            return await _context.Noticias.ToListAsync();
        }

        public int GetTotalNoticias()
        {
            return _context.Noticias.Count();
        }   

    }
}
