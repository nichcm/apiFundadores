using apiFundadores.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiFundadores.Data.Map
{
    public class FornecedorMap : IEntityTypeConfiguration<FornecedorModel>
    {
        public void Configure(EntityTypeBuilder<FornecedorModel> builder) 
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(120);
            builder.Property(x => x.Telefone).HasMaxLength(20);
            builder.Property(x => x.Cnpj).IsRequired().HasMaxLength(20);
        }
    }
}
