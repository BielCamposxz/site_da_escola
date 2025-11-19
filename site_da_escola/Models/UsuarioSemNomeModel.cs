using System.ComponentModel.DataAnnotations;

namespace site_da_escola.Models
{
    public class UsuarioSemNomeModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Esse campo nao pode esta vazio")]
        [EmailAddress(ErrorMessage = "Digite um email valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Esse campo nao pode esta vazio")]
        public string Senha { get; set; }
        public bool IsAdmin { get; set; }


        public bool ValidarSenha(string senha)
        {
            if (Senha == senha)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
