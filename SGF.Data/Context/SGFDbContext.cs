using Microsoft.EntityFrameworkCore;
using SGF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SGF.Data.Context
{
    public class SGFDbContext : DbContext
    {
        public SGFDbContext(DbContextOptions<SGFDbContext> options) : base(options) { }

        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Mes> Meses { get; set; }
        public DbSet<DespesaMes> DespesasMeses { get; set; }
        public DbSet<Remuneracao> Remuneracoes { get; set; }
        public DbSet<RemuneracaoMes> RemuneracoesMeses { get; set; }
        public DbSet<SaldoMes> SaldoMeses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SGFDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
