using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SGF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGF.Data.Mappings
{
    public class DespesaMapping : IEntityTypeConfiguration<Despesa>
    {
        public void Configure(EntityTypeBuilder<Despesa> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Nome)
                .IsRequired()
                .HasColumnType("varchar(15)");

            builder.Property(d => d.Descricao)
                .HasColumnType("varchar(100)");

            builder.Property(d => d.Valor)
                .IsRequired()
                .HasColumnType("varchar(8,2)");

            builder.Property(d => d.DiaVencimento)
                .IsRequired();

        }
    }
}
