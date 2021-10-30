using Microsoft.EntityFrameworkCore;
using SGF.Data.Context;
using SGF.Domain.Entities;
using SGF.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Data.Repository
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly SGFDbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public RepositoryBase(SGFDbContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }
        public virtual async Task Adicionar(TEntity entidade)
        {
            DbSet.Add(entidade);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entidade)
        {
            DbSet.Update(entidade);
            await SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> BuscarPorExpressao(Expression<Func<TEntity, bool>> predicado)
        {
            return await DbSet.AsNoTracking().Where(predicado).ToListAsync();
        }

        public async Task<TEntity> ObterEntidadePorId(Guid Id)
        {
            return await DbSet.FindAsync(Id);
        }

        public async Task<List<TEntity>> ObterTodasEntidades()
        {
            return await DbSet.ToListAsync();
        }

        public async Task Remover(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}
