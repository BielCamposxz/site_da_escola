using Microsoft.EntityFrameworkCore;
using site_da_escola.Data;
using site_da_escola.Models;

namespace site_da_escola.Repositorio.Fixados
{
    public class FixadosEventos : IFixadosEventos
    {
        private readonly BancoContext _bancoContext;

        public FixadosEventos(BancoContext bancoContext)
        {
                _bancoContext = bancoContext;
        }

        public EventosModel BuscarPorId(int id)
        {
            return _bancoContext.Eventos.FirstOrDefault(e => e.Id == id);
        }

        public FixadosTemprariamenteModel CriarFixado(int id)
        {
            var evento = BuscarPorId(id);

            var fixadoTemp = new FixadosTemprariamenteModel
            {
                Id_Estrangeiro = evento.Id,
                Tipo = "Eventos",
                Titulo = evento.Titulo,
                Descricao = evento.Descricao,
                Imagem = evento.Imagem,
                NomeArquivo = evento.NomeArquivo,
                ContentType = evento.ContentType,
                DataDePostagem = evento.DataDePostagem
            };

            _bancoContext.FixadosTemprariamente.Add(fixadoTemp);
            _bancoContext.SaveChanges();

            return fixadoTemp;
        }

        public FixadosModel EnviarFixado(int eventoId)
        {
            var temp = CriarFixado(eventoId);

            var fixado = new FixadosModel
            {
                Id_Estrangeiro = temp.Id_Estrangeiro,
                Tipo = "Eventos",
                Titulo = temp.Titulo,
                Descricao = temp.Descricao,
                Imagem = temp.Imagem,
                NomeArquivo = temp.NomeArquivo,
                ContentType = temp.ContentType,
                DataDePostagem = temp.DataDePostagem
            };


            _bancoContext.Fixados.Add(fixado);

            _bancoContext.FixadosTemprariamente.Remove(temp);

            _bancoContext.SaveChanges();

            return fixado;
        }

        public FixadosTemprariamenteModel BuscarFixadosTemporarios(int id)
        {
            return _bancoContext.FixadosTemprariamente.FirstOrDefault(e => e.Id == id);
        }

        public List<FixadosModel> GetTodosFixados()
        {
            return _bancoContext.Fixados
                .OrderByDescending(f => f.Id)
                .ToList();
        }


        public int GetTotaFixadosTemporariamente()
        {
            return _bancoContext.Fixados.Count();
        }
    }
}
