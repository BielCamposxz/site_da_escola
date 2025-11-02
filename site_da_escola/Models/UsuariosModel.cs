namespace site_da_escola.Models
{
    public class UsuariosModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public bool IsAdmin { get; set; }

        public bool ValidarSenha(string senha)
        {
            if(Senha == senha)
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
