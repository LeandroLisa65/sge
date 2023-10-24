using Contract.Entities;
using Domain.Entities;
using Response;

namespace Application.Services;

public interface IBaseService<TEntity, TResponse>
    where TEntity : EntityBase
    where TResponse : EntityBaseResponse
{
    Task<ResponseData<TResponse>> GetAsync(long? id);
    Task<ResponseData<long>> AddAsync(TEntity entity);
    Task<ResponseData<TResponse>> UpdateAsync(long id, TEntity entity);
    Task<ResponseData<TResponse>> DeleteAsync(long? id);
}