using EMS.Domain.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Persistence.Repository
{
    public abstract class RepositoryBase<TDbContext, TEntity> : IRepositoryBase<TEntity> where TEntity : class where TDbContext : DbContext
    {

        internal readonly TDbContext context;


        private readonly DbSet<TEntity> dbSet;


        public RepositoryBase(TDbContext context)
        {
            this.context = context;
            dbSet = this.context.Set<TEntity>();
        }


        public virtual async Task<IQueryable<TEntity>> AsQueryableAsync()
        {
            return await Task.Run(() => dbSet.AsQueryable());
        }


        public virtual async Task<IQueryable<TEntity>> IncludeMultiple(params Expression<Func<TEntity, object>>[] includes)
        {
            return await Task.Run(() =>
            {
                IQueryable<TEntity> query = dbSet.AsQueryable();
                if (includes is not null)
                {
                    query = includes.Aggregate(query, (current, include) => current.Include(include));
                }

                return query;
            });
        }


        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }


        public virtual async Task<ICollection<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }



        public virtual async Task<TEntity?> GetBySystemNameAsync(Guid systemName)
        {
            return await context.FindAsync<TEntity>(systemName);
        }


        public virtual async Task<TEntity?> FindOneAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.FirstOrDefaultAsync(predicate);
        }


        public virtual TEntity? FindOne(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.FirstOrDefault(predicate);
        }


        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.AnyAsync(predicate);
        }


        public virtual bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Any(predicate);
        }


        public virtual async Task<int> CountAsync()
        {
            return await dbSet.CountAsync();
        }


        public virtual int Count()
        {
            return dbSet.Count();
        }


        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.CountAsync(predicate);
        }


        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Count(predicate);
        }


        public virtual async Task AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public int Add(TEntity entity)
        {

            dbSet.Add(entity);

            return 1;
        }


        public virtual async Task AddAsync(IEnumerable<TEntity> entities)
        {
            await dbSet.AddRangeAsync(entities);
        }


        public virtual void Add(IEnumerable<TEntity> entities)
        {
            dbSet.AddRange(entities);
        }


        public virtual async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => dbSet.Update(entity));
        }


        public virtual void Update(TEntity entity)
        {
            Task.Run(() => dbSet.Update(entity));
        }

        public virtual async Task UpdateAsync(List<TEntity> entities)
        {
            await Task.Run(() => dbSet.UpdateRange(entities));
        }


        public virtual void Update(List<TEntity> entities)
        {
            Task.Run(() => dbSet.UpdateRange(entities));
        }


        public virtual async Task RemoveAsync(TEntity entity)
        {
            await Task.Run(() => dbSet.Remove(entity));
        }


        public void Remove(TEntity entity)
        {
            dbSet.Remove(entity);
        }


        public virtual async Task RemoveAsync(List<TEntity> entities)
        {
            await Task.Run(() => dbSet.RemoveRange(entities));
        }


        public virtual void Remove(List<TEntity> entities)
        {
            Task.Run(() => dbSet.RemoveRange(entities));
        }


        public virtual async Task RemoveAsync(Expression<Func<TEntity, bool>> predicate)
        {
            await Task.Run(async () =>
            {
                IQueryable<TEntity> objects = Where(predicate);
                dbSet.RemoveRange(objects);
            });
        }


        public virtual void Remove(Expression<Func<TEntity, bool>> predicate)
        {
            Task.Run(() =>
            {
                IQueryable<TEntity> objects = Where(predicate);
                dbSet.RemoveRange(objects);
            });
        }

        //public async Task<List<TEntity>> PaginationData(PagingationParms userParms)
        //{
        //    return await Task.Run(() =>
        //    {
        //        IQueryable<TEntity> query = dbSet.AsQueryable<TEntity>();

        //        if (userParms.CurrentPageNumber > 0 && userParms.PageSize > 0)
        //        {
        //            int itemsToSkip = (userParms.CurrentPageNumber - 1) * userParms.PageSize;
        //            query = query.Skip(itemsToSkip).Take(userParms.PageSize);
        //        }

        //        return query.ToListAsync();
        //    });
        //}
    }
}
