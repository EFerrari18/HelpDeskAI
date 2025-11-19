using HelpDeskAI.Models;
using Microsoft.EntityFrameworkCore;

namespace HelpDeskAI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Chamado> Chamado { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<HistoricoChamado> HistoricoChamado { get; set; }
        public DbSet<FaqPergunta> FaqPergunta { get; set; }
    }
}
