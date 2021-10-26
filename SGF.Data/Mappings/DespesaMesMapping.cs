using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGF.Domain.Entities;

namespace SGF.Data.Mappings
{
    public class DespesaMesMapping : IEntityTypeConfiguration<DespesaMes>
    {
        public void Configure(EntityTypeBuilder<DespesaMes> builder)
        {
            builder.HasKey(dm => new { dm.DespesaId, dm.MesId });

            builder.HasOne(dm => dm.Despesa)
                .WithMany(d => d.DespesaMeses)
                .HasForeignKey(dm => dm.DespesaId);

            builder.HasOne(dm => dm.Mes)
                .WithMany(m => m.DespesaMeses)
                .HasForeignKey(dm => dm.MesId);
        }
    }
}
