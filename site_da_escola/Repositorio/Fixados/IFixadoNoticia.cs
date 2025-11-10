using site_da_escola.Models;

namespace site_da_escola.Repositorio.Fixados
{
    public interface IFixadosNoticias
    {
        public FixadosTemprariamenteModel CriarFixado(int id); 
        public FixadosModel EnviarFixado(int id);            
        public NoticiasModel BuscarPorId(int id);           
        public FixadosTemprariamenteModel BuscarFixadosTemporarios(int id); 
        public List<FixadosModel> GetTodosFixados();         
        public int GetTotaFixadosTemporariamente();          
    }
}
