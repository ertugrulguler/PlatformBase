using PlatformBase.Repository.Abstract;
using System.Linq.Expressions;

namespace PlatformBase.Repository.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {

        public Task<T> AnyByAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<T> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> FilterByAsync(Expression<Func<IEnumerable<T>, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<T> FirstOrDefaultByAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<T> SaveAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
