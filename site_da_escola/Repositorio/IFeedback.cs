using site_da_escola.Models;

namespace site_da_escola.Repositorio
{
    public interface IFeedback
    {
        FeedbackModel EnviarFeedback(FeedbackModel feedback);

        List<FeedbackModel> buscarFeedback();
    }
}
