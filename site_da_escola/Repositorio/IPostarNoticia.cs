using site_da_escola.Models;

namespace site_da_escola.Repositorio
{
    public interface IPostarNoticia
    {
        Task CriarPostagemNoticia(NoticiasModel postagem, IFormFile arquivo);
        Task<List<NoticiasModel>> ListarEventos();

        int GetTotalNoticias();

    }
}
