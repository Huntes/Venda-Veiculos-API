using Microsoft.EntityFrameworkCore;
using VendaVeiculosAPI.Models;

namespace VendaVeiculosAPI.Repositories
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Car> Carros { get; set; }
        public DbSet<Arquivo> Arquivos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<CarroArquivo> CarroArquivos { get; set; }
        public DbSet<UsuarioArquivo> UsuarioArquivos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
