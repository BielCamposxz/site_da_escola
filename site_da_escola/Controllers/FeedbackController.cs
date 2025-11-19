using Microsoft.AspNetCore.Mvc;
using site_da_escola.filter;
using site_da_escola.Helper;
using site_da_escola.Models;
using site_da_escola.Repositorio;

namespace site_da_escola.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly ISessao _sessao;
        private readonly IFeedback _feedback;

        public FeedbackController(ISessao sessao, IFeedback feedback)
        {
            _sessao = sessao;
            _feedback = feedback;
        }

        [HttpPost]
        [PaginaRestritaParaUserNaoLogado]
        public IActionResult Enviar(FeedbackUsuarioModel model)
        {
            var usuario = _sessao.BuscarSessaoDoUsuario();

            if (usuario == null)
            {
                TempData["Erro"] = "Você precisa estar logado para enviar feedback.";
                return RedirectToAction("Index", "Home");
            }

            if (model.feedback == null)
            {
                model.feedback = new FeedbackModel();
            }

            model.feedback.Nome = usuario.Nome;

            _feedback.EnviarFeedback(model.feedback);

            return RedirectToAction("Index", "Feedback");
        }

        public IActionResult Index()
        {
            var usuario = _sessao.BuscarSessaoDoUsuario();

            if (usuario == null)
            {
                TempData["Erro"] = "Você precisa estar logado para enviar feedback.";
                return RedirectToAction("Login", "Home");
            }

            var feedbacks = _feedback.buscarFeedback();

            var model = new FeedbackUsuarioModel
            {
                usuario = usuario,
                feedback = new FeedbackModel
                {
                    Nome = usuario.Nome 
                },
                listaFeedbacks = feedbacks
            };

            return View(model);
        }
    }
}
