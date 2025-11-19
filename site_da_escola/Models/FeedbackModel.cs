using site_da_escola.Enum;

namespace site_da_escola.Models
{
    public class FeedbackModel
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public estrelasEnum estrelas { get; set; }

        public string descricao { get; set; } 
    }
}
