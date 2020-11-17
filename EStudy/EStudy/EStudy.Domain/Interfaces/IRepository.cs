using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EStudy.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<string> CreateAsync(TEntity entity);
        Task<string> CreateRangeAsync(IList<TEntity> entities);
        Task<string> UpdateAsync(TEntity entity);
        Task<string> UpdateRangeAsync(IList<TEntity> entities);
        Task<string> RemoveAsync(TEntity entity);
        Task<string> RemoveRangeAsync(IList<TEntity> entities);
        Task<TEntity> FindByIdAsync(object id);
        Task<TEntity> FirstAsync();
        Task<TEntity> LastAsync();
        Task<TEntity> GetByWhereAsync(Expression<Func<TEntity, bool>> match);
        Task<TEntity> GetByWhereAsTrackingAsync(Expression<Func<TEntity, bool>> match);
        Task<List<TEntity>> GetListByWhereAsTrackingAsync(Expression<Func<TEntity, bool>> match);
        Task<List<TEntity>> GetListByWhereAsync(Expression<Func<TEntity, bool>> match);
        Task<List<TEntity>> GetAllAsync();
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<TEntity, bool>> match);
        Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> match);
    }
}