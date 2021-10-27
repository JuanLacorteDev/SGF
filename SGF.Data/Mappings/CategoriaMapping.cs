using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGF.Domain.Entities;

namespace SGF.Data.Mappings
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasMany(c => c.Despesas)
                .WithOne(d => d.Categoria)
                .HasForeignKey(d => d.CategoriaId);
        }
    }
}
