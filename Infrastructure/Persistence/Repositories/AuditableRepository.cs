#region

using System.Linq.Expressions;
using Application.Common.Persistance.Repositories;
using Domain.Entities;

#endregion

namespace Infrastructure.Persistence.Repositories;

public class AuditableRepository<T> : EntityBaseRepository<T> where T : AuditableEntity
{
    public AuditableRepository(ApplicationDbContext applicationDbContext) 
        : base(applicationDbContext) 
    {
    }

    public override async Task<long> AddAsync(T entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
        entity.LastChangeDate = DateTime.UtcNow;
        entity.IsActive = true;

        var result = await base.AddAsync(entity);

        return result;
    }

    public override async Task UpdateAsync(T entity)
    {
        entity.LastChangeDate = entity.CreatedDate.ToUniversalTime();
        entity.LastChangeDate = DateTime.UtcNow;
        await base.UpdateAsync(entity);
    }

    public override async Task DeleteAsync(T entity)
    {
        entity.IsActive = false;        
        await UpdateAsync(entity);
    }
}

