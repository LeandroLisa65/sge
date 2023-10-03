using System.Linq.Expressions;
using Domain.Entities;

namespace Application.Common.Persistance.Repositories;

public interface IRepository<T> where T : EntityBase
{
    Task<T?> GetAsync(long id);
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> GetAllAsync();
    Task<long> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> predicate, int? skip, int? take);
}