using back.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace back.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext   
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) { }
        
        public DbSet<ItensModel> Itens { get; set; }
        public DbSet<SolicitacoesModel> Solicitacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
