using System.Data.Entity;
using Dominio;

namespace BomDiaBrasilTreinamento.Web.Models
{
    public class BomDiaBrasilContext : DbContext
    {
        public DbSet<Comentario> Comentario;
        public DbSet<Empregado> Empregado;
        public DbSet<Participante> Participante;
        public DbSet<Reportagem> Reportagem;

        public BomDiaBrasilContext() : base("TreinamentoDb")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reportagem>()
                .HasRequired(r => r.Equipe);
            modelBuilder.Entity<Reportagem>()
                .HasRequired(r => r.Comentarios);
            modelBuilder.Entity<Reportagem>()
                .HasRequired(r => r.Participantes);
        }

        public System.Data.Entity.DbSet<Dominio.Comentario> Comentarios { get; set; }
    }
}