using System.Linq;
using System.Threading.Tasks;
using System;
using System.Linq.Expressions;

namespace CastGroup.Interfaces
{
    public interface IRepositoryBase<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(Guid id);

        IQueryable<TEntity> Include<T>(Expression<Func<TEntity, Object>> criteria);

        Task<Guid> Create(TEntity entity);

        Task Update(Guid id, TEntity entity);

        Task Delete(Guid id);
    }
}