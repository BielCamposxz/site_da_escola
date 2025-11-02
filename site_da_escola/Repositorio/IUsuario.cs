using site_da_escola.Models;

namespace site_da_escola.Repositorio
{
    public interface IUsuario
    {
        public int GetTotalUsuarios();
        public UsuariosModel Registrar(UsuariosModel usuario);
        public string UsuarioExiste(UsuariosModel usuario);

        public UsuariosModel BuscarUsuarioPorEmail(UsuariosModel usuarioModel);

    }
}
