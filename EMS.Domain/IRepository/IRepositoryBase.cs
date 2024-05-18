using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.IRepository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<IQueryable<TEntity>> AsQueryableAsync();

        Task<IQueryable<TEntity>> IncludeMultiple(params Expression<Func<TEntity, object>>[] includes);


        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

        Task<ICollection<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> GetAllAsync();

        Task<TEntity?> GetBySystemNameAsync(Guid systemName);

        Task<TEntity?> FindOneAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity? FindOne(Expression<Func<TEntity, bool>> predicate);

        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);

        bool Exists(Expression<Func<TEntity, bool>> predicate);

        Task<int> CountAsync();

        int Count();

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        int Count(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);

        Task AddAsync(IEnumerable<TEntity> entities);

        void Add(IEnumerable<TEntity> entities);

        Task UpdateAsync(TEntity entity);

        void Update(TEntity entity);

        Task UpdateAsync(List<TEntity> entities);

        void Update(List<TEntity> entities);
        
        Task RemoveAsync(TEntity entity);

        void Remove(TEntity entity);

        Task RemoveAsync(List<TEntity> entities);

        void Remove(List<TEntity> entities);

        Task RemoveAsync(Expression<Func<TEntity, bool>> predicate);

        void Remove(Expression<Func<TEntity, bool>> predicate);

        //Task<List<TEntity>> PaginationData(PagingationParms userParms);

    }
}
