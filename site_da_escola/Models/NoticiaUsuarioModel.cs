namespace site_da_escola.Models
{
    public class NoticiaUsuarioModel
    {
        public NoticiasModel Noticias {  get; set; }
        public UsuariosModel usuario {  get; set; }

        public List<NoticiasModel> NoticiasTotal { get; set; }
    }
}
