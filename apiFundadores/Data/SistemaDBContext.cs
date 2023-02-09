using apiFundadores.Data.Map;
using apiFundadores.Models;
using Microsoft.EntityFrameworkCore;

namespace apiFundadores.Data
{
    public class SistemaDBCOntext : DbContext
    {

        public SistemaDBCOntext(DbContextOptions<SistemaDBCOntext> options):
            base(options)
        { 
        }

        public DbSet<FornecedorModel> Fonrnecedores { get; set; }
        public DbSet<EnderecoModel> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FornecedorMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
