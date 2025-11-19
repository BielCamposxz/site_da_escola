namespace site_da_escola.Models
{
    public class FeedbackUsuarioModel
    {
        public FeedbackModel feedback {  get; set; }
        public UsuariosModel usuario {  get; set; }

        public List<FeedbackModel> listaFeedbacks { get; set; }

    }
}
