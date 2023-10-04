#region

using System.Linq.Expressions;
using Contract.Entities;
using Domain.Entities;

#endregion

namespace Application.Services;

public interface IAuditableService<TEntity, TResponse> : IBaseService<TEntity, TResponse>
    where TEntity : AuditableEntity
    where TResponse : EntityBaseResponse
{
    Task<ResponseData<IEnumerable<TResponse>>> GetAllAsync();
    Task<ResponseData<TResponse>> GetAsync(Expression<Func<TEntity, bool>> predicate);
    Task<ResponseData<IEnumerable<TResponse>>> GetManyAsync(Expression<Func<TEntity, bool>> predicate);
}

