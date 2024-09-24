using Appointments.Application.IRepositories;
using Appointments.Domain.Models;
using Appointments.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Appointments.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppointmentContext context;

        public GenericRepository(AppointmentContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public TEntity Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await context.Set<TEntity>().AddAsync(entity, cancellationToken).ConfigureAwait(false);
            return entity;
        }

        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().AddRange(entities);
            return entities;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await context.Set<TEntity>().AddRangeAsync(entities, cancellationToken).ConfigureAwait(false);
            return entities;
        }

        public bool Any(Expression<Func<TEntity, bool>> anyExpression)
        {
            return context.Set<TEntity>().Any(anyExpression);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> anyExpression, CancellationToken cancellationToken = default)
        {
            bool result = await context.Set<TEntity>().AnyAsync(anyExpression, cancellationToken).ConfigureAwait(false);
            return result;
        }

        public int Count()
        {
            return context.Set<TEntity>().Count();
        }

        public int Count(Expression<Func<TEntity, bool>> whereExpression)
        {
            return context.Set<TEntity>().Where(whereExpression).Count();
        }

        public async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            int count = await context.Set<TEntity>().CountAsync(cancellationToken).ConfigureAwait(false);
            return count;
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> whereExpression, CancellationToken cancellationToken = default)
        {
            int count = await context.Set<TEntity>().Where(whereExpression).CountAsync(cancellationToken).ConfigureAwait(false);
            return count;
        }

        public TEntity GetById(Guid id, bool asNoTracking = false)
        {
            return context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
        }

        public async Task<TEntity> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
        {
            return await FindQueryable(asNoTracking).FirstOrDefaultAsync(x => x.Id == id, cancellationToken).ConfigureAwait(false);
        }

        public List<TEntity> GetMultiple(bool asNoTracking = false)
        {
            return FindQueryable(asNoTracking).ToList();
        }

        public List<TEntity> GetMultiple(Expression<Func<TEntity, bool>> whereExpression, bool asNoTracking = false)
        {
            return FindQueryable(asNoTracking).Where(whereExpression).ToList();
        }

        public async Task<List<TEntity>> GetMultipleAsync(bool asNoTracking = false, CancellationToken cancellationToken = default)
        {
            return await FindQueryable(asNoTracking).ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<List<TEntity>> GetMultipleAsync(Expression<Func<TEntity, bool>> whereExpression, bool asNoTracking = false, CancellationToken cancellationToken = default)
        {
            return await FindQueryable(asNoTracking).Where(whereExpression).ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return context.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> filter)
        {
            return context.Set<TEntity>().Where(filter);
        }

        public TEntity GetSingle(Expression<Func<TEntity, bool>> whereExpression, bool asNoTracking = false)
        {
            var queryable = FindQueryable(asNoTracking).Where(whereExpression);
            return queryable.FirstOrDefault();
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> whereExpression, bool asNoTracking = false, CancellationToken cancellationToken = default)
        {
            var queryable = FindQueryable(asNoTracking).Where(whereExpression);
            return await queryable.FirstOrDefaultAsync(cancellationToken).ConfigureAwait(false);
        }

        public void HardDelete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public void HardDelete(Guid id)
        {
            var entity = context.Set<TEntity>().Find(id);
            context.Set<TEntity>().Remove(entity);
        }

        public Task HardDeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            context.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task HardDeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entity = await context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken).ConfigureAwait(false);
            context.Set<TEntity>().Remove(entity);
        }

        public TEntity Replace(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public Task<TEntity> ReplaceAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            context.Entry(entity).State = EntityState.Modified;
            return Task.FromResult(entity);
        }

        public TEntity Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            return entity;
        }

        public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            context.Set<TEntity>().Update(entity);
            return Task.FromResult(entity);
        }

        public IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().UpdateRange(entities);
            return entities;
        }

        public async Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            context.Set<TEntity>().UpdateRange(entities);
            return entities;
        }

        public void Complete()
        {
            context.SaveChanges();
        }

        public async Task CompleteAsync(CancellationToken cancellationToken = default)
        {
            await context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        private IQueryable<TEntity> FindQueryable(bool asNoTracking)
        {
            var queryable = GetQueryable();
            if (asNoTracking)
            {
                queryable = queryable.AsNoTracking();
            }
            return queryable;
        }

		public async Task DeleteAllAsync()
		{
            var allEntities = await context.Set<TEntity>().ToListAsync();
			context.RemoveRange(allEntities);
            await context.SaveChangesAsync();
		}
	}
}
