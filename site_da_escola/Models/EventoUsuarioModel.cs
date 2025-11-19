namespace site_da_escola.Models
{
    public class EventoUsuarioModel
    {
        public EventosModel Eventos {  get; set; }
        public UsuariosModel usuario {  get; set; }

        public List<EventosModel> TotalEventos { get; set; }


    }
}
