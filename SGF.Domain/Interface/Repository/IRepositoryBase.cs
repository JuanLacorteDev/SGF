using SGF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SGF.Domain.Interface.Repository
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : BaseEntity
    {
        Task Adicionar(TEntity entidade);
        Task<TEntity> ObterEntidadePorId(Guid Id);
        Task<List<TEntity>> ObterTodasEntidades();
        Task Atualizar(TEntity entidade);
        Task Remover(Guid id);
        Task<IEnumerable<TEntity>> BuscarPorExpressao(Expression<Func<TEntity, bool>> predicado);
        Task<int> SaveChanges();

    }
}
