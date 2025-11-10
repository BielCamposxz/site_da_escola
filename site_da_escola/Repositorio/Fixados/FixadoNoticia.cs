using Microsoft.EntityFrameworkCore;
using site_da_escola.Data;
using site_da_escola.Models;

namespace site_da_escola.Repositorio.Fixados
{
    public class FixadosNoticias : IFixadosNoticias
    {
        private readonly BancoContext _bancoContext;

        public FixadosNoticias(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public NoticiasModel BuscarPorId(int id)
        {
            return _bancoContext.Noticias.FirstOrDefault(n => n.Id == id);
        }

        public FixadosTemprariamenteModel CriarFixado(int id)
        {
            var noticia = BuscarPorId(id);
            if (noticia == null) return null;

            var fixadoTemp = new FixadosTemprariamenteModel
            {
                Id_Estrangeiro = noticia.Id,
                Tipo = "Noticias",

                Titulo = noticia.Titulo,
                Descricao = noticia.Descricao,
                Imagem = noticia.Imagem,
                NomeArquivo = noticia.NomeArquivo,
                ContentType = noticia.ContentType,
                DataDePostagem = noticia.DataDePostagem
            };

            _bancoContext.FixadosTemprariamente.Add(fixadoTemp);
            _bancoContext.SaveChanges();

            return fixadoTemp;
        }

        public FixadosModel EnviarFixado(int noticiaId)
        {
            var temp = CriarFixado(noticiaId);
            if (temp == null) return null;

            var fixado = new FixadosModel
            {
                Id_Estrangeiro = temp.Id_Estrangeiro,
                Tipo = "Noticias",
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
            return _bancoContext.FixadosTemprariamente.FirstOrDefault(f => f.Id == id);
        }

        public List<FixadosModel> GetTodosFixados()
        {
            return _bancoContext.Fixados
                .OrderByDescending(f => f.Id)
                .ToList();
        }

        public int GetTotaFixadosTemporariamente()
        {
            return _bancoContext.FixadosTemprariamente.Count();
        }
    }
}
