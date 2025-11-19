using site_da_escola.Models;
using site_da_escola.Data;
using site_da_escola.Helper;

namespace site_da_escola.Repositorio
{
    public class Feedback : IFeedback
    {

        private readonly BancoContext _bancoContext;
        private readonly ISessao _sessao;

        public Feedback(BancoContext bancoContext, ISessao sessao)
        {
            _bancoContext = bancoContext;
            _sessao = sessao;   
            
        }
        public List<FeedbackModel> buscarFeedback()
        {
            return _bancoContext.Feedbacks.ToList();
        }

        public FeedbackModel EnviarFeedback(FeedbackModel feedback)
        {
            _bancoContext.Feedbacks.Add(feedback);
            _bancoContext.SaveChanges();
            return feedback;
        }
    }
}
