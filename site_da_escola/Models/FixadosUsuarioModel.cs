namespace site_da_escola.Models
{
    public class FixadosUsuarioModel
    {
        public FixadosModel Fixados {  get; set; }
        public UsuariosModel usuario {  get; set; }

        public List<FixadosModel> FixadosTotal { get; set; }

    }
}
