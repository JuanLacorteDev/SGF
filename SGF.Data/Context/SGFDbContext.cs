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
        public DbSet<Receita> Receitas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SGFDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
