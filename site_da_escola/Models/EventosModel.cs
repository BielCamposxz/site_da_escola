namespace site_da_escola.Models
{
    public class EventosModel
    {
        public int Id { get; set; }

        public string Titulo { get; set; }
        
        public string Descricao { get; set; }

        public byte[] Imagem { get; set; } = Array.Empty<byte>();

        public string NomeArquivo { get; set; } = string.Empty;

        public string ContentType { get; set; } = string.Empty;
        public DateTime DataDePostagem { get; set; }
    }
}
