namespace site_da_escola.Models
{
    public class FixadosModel
    {
        public int Id { get; set; }
        public int Id_Estrangeiro { get; set; }

        public string Tipo { get; set; } 

        public string Titulo { get; set; }
        
        public string Descricao { get; set; }

        public byte[] Imagem { get; set; } = Array.Empty<byte>();

        public string NomeArquivo { get; set; } = string.Empty;

        public string ContentType { get; set; } = string.Empty;
        public DateTime DataDePostagem { get; set; }
    }
}
