using SGF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SGF.Data.Mappings
{
    public class RemuneracaoMapping : IEntityTypeConfiguration<Remuneracao>
    {
        public void Configure(EntityTypeBuilder<Remuneracao> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Valor)
                .HasColumnType("varchar(8,2)");

            builder.Property(r => r.Descricao)
                .HasColumnType("varchar(50)");

        }
    }
}
