using System.Linq.Expressions;

namespace PlatformBase.Repository.Abstract
{
    public interface IGenericRepository<T> where T : class,new()
    {
        Task<T> SaveAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<IEnumerable<T>> FilterByAsync(Expression<Func<IEnumerable<T>, bool>> predicate);
        Task<T> FindByAsync(Expression<Func<T,bool>> predicate);
        Task<T> FirstOrDefaultByAsync(Expression<Func<T, bool>> predicate);
        Task<T> AnyByAsync(Expression<Func<T, bool>> predicate);
    }
}
