#region

using Application.Services.Interfaces;
using AutoMapper;
using Contract.Entities;
using Domain.Entities;

#endregion

namespace Application.Services;

public class RequestMapperService<TRequest, TEntity> : IRequestMapperService<TRequest, TEntity>
    where TEntity : AuditableEntity
{
    private readonly IMapper _mapper;

    public RequestMapperService
        (
            IMapper mapper
        )
    {
        _mapper = mapper;
    }

    public async Task<TEntity> MapToEntityAsync(TRequest requestDto, bool isCreation = true)
    {
        var entity = _mapper.Map<TRequest, TEntity>(requestDto);

        if (isCreation)
            entity.CreatedBy = "admin";
        
        entity.LastChangeBy = "admin";

        return entity;
    }
}