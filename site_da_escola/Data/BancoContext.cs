using Microsoft.EntityFrameworkCore;
using site_da_escola.Models;

namespace site_da_escola.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
                
        }

        public DbSet<NoticiasModel> Noticias { get; set; }
        public DbSet<EventosModel> Eventos { get; set; }
        public DbSet<UsuariosModel> Usuarios { get; set; }
        public DbSet<FeedbackModel> Feedbacks { get; set; }
        public DbSet<FixadosTemprariamenteModel> FixadosTemprariamente { get; set; }
        public DbSet<FixadosModel> Fixados { get; set; }

    }
}
