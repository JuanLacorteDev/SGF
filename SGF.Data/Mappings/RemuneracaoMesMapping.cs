using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGF.Domain.Entities;

namespace SGF.Data.Mappings
{
    class RemuneracaoMesMapping : IEntityTypeConfiguration<RemuneracaoMes>
    {
        public void Configure(EntityTypeBuilder<RemuneracaoMes> builder)
        {
            builder.HasKey(rm => new { rm.MesId, rm.RemuneracaoId });

            builder.HasOne(rm => rm.Remuneracao)
                .WithMany(r => r.RemuneracaoMeses)
                .HasForeignKey(rm => rm.RemuneracaoId);

            builder.HasOne(rm => rm.Mes)
                .WithMany(m => m.RemunecaoMeses)
                .HasForeignKey(rm => rm.MesId); ;
        }
    }
}
