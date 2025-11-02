using Microsoft.EntityFrameworkCore;
using site_da_escola.Data;
using site_da_escola.Models;
using System.Web.Mvc;

namespace site_da_escola.Repositorio
{
    public class Usuario : IUsuario
    { 
        private readonly BancoContext _bancoContext;

        public Usuario(BancoContext bancoContext)
        {
          _bancoContext = bancoContext;
        }

        public string UsuarioExiste(UsuariosModel usuario)
        {
            if (_bancoContext.Usuarios.FirstOrDefault(user => user.Email == usuario.Email) != null)
            {
                return "Email já cadastrado, tente outro";
            }

            return null;
        }

        [HttpPost]
        public UsuariosModel Registrar(UsuariosModel usuario)
        {
            if(UsuarioExiste(usuario) == null)
            {
                usuario.IsAdmin = false;
                _bancoContext.Usuarios.Add(usuario);
                _bancoContext.SaveChanges();
                return usuario;
            }
            else
            {
                return null;
            }
        }

        public UsuariosModel BuscarUsuarioPorEmail(UsuariosModel usuarioModel)
        {
            var usuario = _bancoContext.Usuarios.FirstOrDefault(user => user.Email == usuarioModel.Email);
            if (usuario != null)
            {
                return usuario;
            }
            return null;

        }
        public int GetTotalUsuarios()
        {
            return _bancoContext.Usuarios.Count(); 
        }
    }
}