using site_da_escola.Models;

namespace site_da_escola.Repositorio.Fixados
{
    public interface IFixadosEventos
    {
        public FixadosTemprariamenteModel CriarFixado(int id);
        int GetTotaFixadosTemporariamente();

        public EventosModel BuscarPorId(int id);

        public List<FixadosModel> GetTodosFixados();

        public FixadosTemprariamenteModel BuscarFixadosTemporarios(int id);
        public FixadosModel EnviarFixado(int id);



    }
}
