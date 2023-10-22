#region

using System.Linq.Expressions;
using Application.Common.Persistance.Repositories;
using Common;
using Domain.Entities;

#endregion

namespace Infrastructure.Persistence.Repositories;

public class AuditableRepository<T> : EntityBaseRepository<T>, IAuditableRepository<T> where T : AuditableEntity
{
    public AuditableRepository(ApplicationDbContext applicationDbContext) 
        : base(applicationDbContext) 
    {
    }

    public override async Task<T?> GetAsync(long id)
    {
        return await base.GetAsync(x => x.IsActive && x.Id == id);
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate, bool onlyActives = true)
    {
        if (onlyActives)
            predicate = predicate.And(x => x.IsActive);

        return await base.GetAsync(predicate);
    }

    public override async Task<IEnumerable<T>> GetAllAsync()
    {
        var result = await base.GetManyAsync(x => x.IsActive);

        return result;
    }

    public override async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> predicate)
    {
        var onlyActives = predicate.And(x => x.IsActive);
        var result = await base.GetManyAsync(onlyActives);

        return result;
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
        entity.CreatedDate = entity.CreatedDate.ToUniversalTime();
        entity.LastChangeDate = DateTime.UtcNow;
        await base.UpdateAsync(entity);
    }

    public override async Task DeleteAsync(T entity)
    {
        entity.IsActive = false;        
        await UpdateAsync(entity);
    }
}

