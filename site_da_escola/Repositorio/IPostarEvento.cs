using site_da_escola.Models;

namespace site_da_escola.Repositorio
{
    public interface IPostarEvento
    {
        Task CriarPostagemEvento(EventosModel postagem, IFormFile arquivo);
        Task<List<EventosModel>> ListarEventos();
        int GetTotalEventos();

    }
}
