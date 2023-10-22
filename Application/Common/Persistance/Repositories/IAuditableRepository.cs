using Domain.Entities;

namespace Application.Common.Persistance.Repositories;

public interface IAuditableRepository<T> : IEntityBaseRepository<T> where T : AuditableEntity
{
}