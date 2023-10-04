using Contract.Entities;
using Domain.Entities;

namespace Application.Services;

public interface IBaseService<TEntity, TResponse>
    where TEntity : AuditableEntity
    where TResponse : EntityBaseResponse
{
    Task<ResponseData<TResponse>> GetAsync(long? id);
    Task<ResponseData<long>> AddAsync(TEntity entity);
    Task<ResponseData<TResponse>> UpdateAsync(TEntity entity);
    Task<ResponseData<TResponse>> DeleteAsync(long? id);
}