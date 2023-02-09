using apiFundadores.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apiFundadores.Data.Map
{
    public class EnderecoMap : IEntityTypeConfiguration<EnderecoModel>
    {
        public void Configure(EntityTypeBuilder<EnderecoModel> builder) 
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Rua).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Pais).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Cep).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Estado).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Cidade).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Complemento).HasMaxLength(255);
            builder.Property(x => x.FornecedorModelId);
            builder.HasOne(x => x.FornecedorModel);
        }
    }
}
