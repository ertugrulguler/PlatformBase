using System.Linq.Expressions;
using PlatformBase.Core.Abstract;
using Microsoft.EntityFrameworkCore;
using PlatformBase.Domain.Concrete;
using PlatformBase.Domain.Abstract;

namespace PlatformBase.Repository.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        protected readonly DbContext _dbContext;
        public readonly DbSet<T> _entities;

        protected GenericRepository(DbContext context)
        {
            _entities = context.Set<T>();
            _dbContext = context;
        }
        public async Task<bool> AnyByAsync(Expression<Func<T, bool>> predicate, bool isActive = true)
        {
            return await _entities.Where(i => i.IsActive == isActive).AnyAsync(predicate);
        }

        public void DeleteAsync(T entity)
        {
            entity.IsActive = false;
        }

        public async Task<IEnumerable<T>> FilterByAsync(Expression<Func<T, bool>> predicate, bool isActive = true)
        {
            return await _entities.Where(i => i.IsActive == isActive).Where(predicate).ToListAsync();
        }

        public async Task<T> FindByAsync(Expression<Func<T, bool>> predicate, bool isActive = true)
        {
            return await _entities.Where(i => i.IsActive == isActive).SingleOrDefaultAsync(predicate);
        }

        public async Task<T> FirstOrDefaultByAsync(Expression<Func<T, bool>> predicate, bool isActive = true)
        {
            return await _entities.Where(i => i.IsActive == isActive).FirstOrDefaultAsync(predicate);
        }

        public async Task SaveAsync(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public T UpdateAsync(T entity)
        {
            var entityEntry = _entities.Update(entity);
            return entityEntry.Entity;
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate, bool isActive = true)
        {
            return await _entities.Where(predicate).Where(s => s.IsActive == isActive).CountAsync();
        }

        public async Task<PagedList<T>> FilterByPagingAsync(Expression<Func<T, bool>> predicate, Domain.Concrete.PagerInput pagerInput, bool isActive = true)
        {
            var itemsCount = await CountAsync(predicate);

            var list = await _entities.Where(predicate).Where(s => s.IsActive == isActive).OrderByDescending(c => c.CreatedDate)
                .Skip((pagerInput.PageIndex - 1) * pagerInput.PageSize)
                .Take(pagerInput.PageSize)
                .ToListAsync();

            return new PagedList<T>(list, itemsCount, pagerInput);
        }
        public async Task<bool> Exist(Expression<Func<T, bool>> predicate)
        {
            var exist = _entities.Where(predicate);
            return await exist.AnyAsync();
        }

        public async Task<List<T>> FilterByAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entities.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<List<T>> FilterEagerLoading(Expression<Func<T, bool>> filter = null, Expression<Func<T, T>> select = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "", int? page = null, int? pageSize = null, bool isDistinct = false)
        {
            IQueryable<T> query = _entities.AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            if (select != null)
                query = query.Select(select);

            if (isDistinct)
                query = query.Distinct();

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            if (orderBy != null)
                query = orderBy(query);

            if (page != null && pageSize != null)
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);

            return await query.ToListAsync();
        }
    }
}
