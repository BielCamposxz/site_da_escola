using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using site_da_escola.Models;

namespace site_da_escola.filter
{
    public class PaginaRestritaParaUserNaoLogado : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessaoUsuario = context.HttpContext.Session.GetString("SessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary { { "Controller", "Home" }, { "Action", "Index" } });
                return;
            }

            var usuario = JsonConvert.DeserializeObject<UsuariosModel>(sessaoUsuario);

            if (usuario == null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary { { "Controller", "Home" }, { "Action", "Index" } });
                return;
            }
        }
    }
}
