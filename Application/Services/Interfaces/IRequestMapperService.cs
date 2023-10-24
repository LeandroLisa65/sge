#region

using Contract.Entities;
using Domain.Entities;

#endregion

namespace Application.Services.Interfaces;
public interface IRequestMapperService<TRequest, TEntity>
    where TEntity : AuditableEntity
{
    Task<TEntity> MapToEntityAsync(TRequest requestDto, bool isCreation = true);
}