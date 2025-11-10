using site_da_escola.Models;

namespace site_da_escola.Helper
{
    public interface ISessao
    {
        void CriarSessaoDoUsuario(UsuariosModel sessao);
        void ApagarSessaoUsuario();
        UsuariosModel BuscarSessaoDoUsuario();

    }
}
