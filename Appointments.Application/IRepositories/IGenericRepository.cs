using Appointments.Domain.Models;
using System.Linq.Expressions;

namespace Appointments.Application.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Add(TEntity entity);

        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);

        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        void HardDelete(TEntity entity);

        Task HardDeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

        void HardDelete(Guid id);

        Task HardDeleteAsync(Guid id, CancellationToken cancellationToken = default);

        TEntity Update(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities);

        Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        TEntity Replace(TEntity entity);

        Task<TEntity> ReplaceAsync(TEntity entity, CancellationToken cancellationToken = default);

        IQueryable<TEntity> GetQueryable();

        IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> filter);

        List<TEntity> GetMultiple(bool asNoTracking = false);

        Task<List<TEntity>> GetMultipleAsync(bool asNoTracking = false, CancellationToken cancellationToken = default);

        List<TEntity> GetMultiple(Expression<Func<TEntity, bool>> whereExpression, bool asNoTracking = false);

        Task<List<TEntity>> GetMultipleAsync(Expression<Func<TEntity, bool>> whereExpression, bool asNoTracking = false, CancellationToken cancellationToken = default);

        TEntity GetSingle(Expression<Func<TEntity, bool>> whereExpression, bool asNoTracking = false);

        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> whereExpression, bool asNoTracking = false, CancellationToken cancellationToken = default);

        TEntity GetById(Guid id, bool asNoTracking = false);

        Task<TEntity> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default);

        bool Any(Expression<Func<TEntity, bool>> anyExpression);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> anyExpression, CancellationToken cancellationToken = default);

        int Count();

        Task<int> CountAsync(CancellationToken cancellationToken = default);

        int Count(Expression<Func<TEntity, bool>> whereExpression);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> whereExpression, CancellationToken cancellationToken = default);

        void Complete();

        Task CompleteAsync(CancellationToken cancellationToken = default);
    }
}
