using System.Linq.Expressions;
using PlatformBase.Core.Abstract;
using PlatformBase.Domain.Concrete;

namespace PlatformBase.Domain.Abstract
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task SaveAsync(T entity);
        T UpdateAsync(T entity);
        void DeleteAsync(T entity);
        Task<IEnumerable<T>> FilterByAsync(Expression<Func<T, bool>> predicate, bool isActive = true);
        Task<T> FindByAsync(Expression<Func<T, bool>> predicate, bool isActive = true);
        Task<T> FirstOrDefaultByAsync(Expression<Func<T, bool>> predicate, bool isActive = true);
        Task<bool> AnyByAsync(Expression<Func<T, bool>> predicate, bool isActive = true);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate, bool isActive = true);
        Task<PagedList<T>> FilterByPagingAsync(Expression<Func<T, bool>> predicate, PagerInput pagerInput, bool isActive = true);
        Task<List<T>> FilterEagerLoading(Expression<Func<T, bool>> filter = null, Expression<Func<T, T>> select = null,
                    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                    string includeProperties = "", int? page = null, int? pageSize = null, bool isDistinct = false);
        Task<bool> Exist(Expression<Func<T, bool>> predicate);
        Task<List<T>> FilterByAllAsync(Expression<Func<T, bool>> predicate);
    }
}