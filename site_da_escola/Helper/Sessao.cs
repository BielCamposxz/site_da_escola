using Newtonsoft.Json;
using site_da_escola.Models;

namespace site_da_escola.Helper
{
    public class Sessao : ISessao
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public Sessao(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void ApagarSessaoUsuario()
        {
            _httpContextAccessor.HttpContext.Session.Remove("SessaoUsuarioLogado");
        }


        public UsuariosModel BuscarSessaoDoUsuario()
        {
            string sessaoUsuario = _httpContextAccessor.HttpContext.Session.GetString("SessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<UsuariosModel>(sessaoUsuario);
            }
        }

        public void CriarSessaoDoUsuario(UsuariosModel sessao)
        {
            string usuario = JsonConvert.SerializeObject(sessao);
            _httpContextAccessor.HttpContext.Session.SetString("SessaoUsuarioLogado", usuario);
        }

      
    }
}
