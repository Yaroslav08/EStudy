using EStudy.Constants;
using EStudy.Domain.Interfaces;
using EStudy.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EStudy.Infrastructure.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly EStudyContext db;
        protected readonly DbSet<TEntity> dbSet;
        public Repository()
        {
            db = new EStudyContext();
            dbSet = db.Set<TEntity>();
        }

        public async Task<int> CountAsync()
        {
            return await db.Set<TEntity>().AsNoTracking().CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> match)
        {
            return await db.Set<TEntity>().AsNoTracking().CountAsync(match);
        }

        public async Task<string> CreateAsync(TEntity entity)
        {
            await db.Set<TEntity>().AddAsync(entity);
            return await SaveAsync();
        }

        public async Task<string> CreateRangeAsync(IList<TEntity> entities)
        {
            await db.Set<TEntity>().AddRangeAsync(entities);
            await SaveAsync();
            return EStudy.Constants.Constants.OK;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await db.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByWhereAsTrackingAsync(Expression<Func<TEntity, bool>> match)
        {
            return await db.Set<TEntity>().FirstOrDefaultAsync(match);
        }

        public async Task<TEntity> GetByWhereAsync(Expression<Func<TEntity, bool>> match)
        {
            return await db.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(match);
        }

        public async Task<List<TEntity>> GetListByWhereAsTrackingAsync(Expression<Func<TEntity, bool>> match)
        {
            return await db.Set<TEntity>().Where(match).ToListAsync();
        }

        public async Task<List<TEntity>> GetListByWhereAsync(Expression<Func<TEntity, bool>> match)
        {
            return await db.Set<TEntity>().AsNoTracking().Where(match).ToListAsync();
        }

        public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> match)
        {
            return await db.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(match) != null ? true : false;
        }

        public async Task<string> RemoveAsync(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
            await SaveAsync();
            return EStudy.Constants.Constants.OK;
        }

        public async Task<string> RemoveRangeAsync(IList<TEntity> entities)
        {
            db.Set<TEntity>().RemoveRange(entities);
            await SaveAsync();
            return EStudy.Constants.Constants.OK;
        }

        public async Task<string> SaveAsync()
        {
            return await db.SaveChangesAsync() > 0 ? EStudy.Constants.Constants.OK : EStudy.Constants.Constants.Error;
        }

        public async Task<string> UpdateAsync(TEntity entity)
        {
            db.Set<TEntity>().Update(entity);
            return await SaveAsync();
        }

        public async Task<string> UpdateRangeAsync(IList<TEntity> entities)
        {
            db.Set<TEntity>().UpdateRange(entities);
            await SaveAsync();
            return EStudy.Constants.Constants.OK;
        }
    }
}
