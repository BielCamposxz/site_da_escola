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

        public UsuariosModel BuscarUsuarioPorEmail(string email)
        {
            var usuario = _bancoContext.Usuarios.FirstOrDefault(user => user.Email == email);
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

        public List<UsuariosModel> BuscarTodosUsuario()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public bool ApagarUsuario(int id)
        {
            UsuariosModel usuario = BuscarUsuarioPorId(id);

            if(usuario == null)
            {
                return false;
            }
            else
            {
                _bancoContext.Usuarios.Remove(usuario);
                _bancoContext.SaveChanges();
                return true;
            }
        }

        public UsuariosModel BuscarUsuarioPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(user => user.Id == id);
        }

        public UsuariosModel Editar(UsuariosModel usuario)
        {
           UsuariosModel usuarioDb = BuscarUsuarioPorId(usuario.Id);
            if(usuarioDb == null) 
            {
                return null;
            }
            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Email = usuario.Email;
            usuarioDb.Senha = usuario.Senha;
            _bancoContext.Usuarios.Update(usuarioDb);
            _bancoContext.SaveChanges();
            return usuarioDb;
        }
    }
}