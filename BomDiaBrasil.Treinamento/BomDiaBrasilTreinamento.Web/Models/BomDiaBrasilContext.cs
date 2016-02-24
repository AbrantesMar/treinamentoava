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
            // DbModelBuilder modelBuilder
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Entity<Reportagem>().HasMany(r => r.Comentarios);
            //modelBuilder.Entity<Reportagem>().HasMany(r => r.Participantes);
            //modelBuilder.Entity<Reportagem>().HasMany(r => r.Equipe);
        }
    }
}