using CleanArchitecture.Domain.Common;
using System.Linq.Expressions;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : BaseDomainModel
    {
        Task<IReadOnlyCollection<T>> GetAllAsync();

        Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>> predicate);

        Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>>? predicate,
            Func<IQueryable<T>, IOrderedEnumerable<T>>? orderBy,
            string? includeString,
            bool disableTracking = true);

        Task<IReadOnlyCollection<T>> GetAllAsync(Expression<Func<T, bool>>? predicate,
            Func<IQueryable<T>, IOrderedEnumerable<T>>? orderBy,
            List<Expression<Func<T, object>>> includes, 
            bool disableTracking = true);

        Task<T> GetByIdAsync(int id);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<T> DeleteAsync(T entity);
    }
}
