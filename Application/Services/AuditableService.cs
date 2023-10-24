using System.Linq.Expressions;
using Application.Common.Persistance.Repositories;
using ATC.Domain.Exceptions;
using AutoMapper;
using Contract.Entities;
using Domain.Entities;
using FluentValidation;
using Response;

namespace Application.Services;

public class AuditableService<TEntity, TResponse> : BaseService<TEntity, TResponse> ,IAuditableService<TEntity, TResponse>
where TEntity : AuditableEntity
where TResponse : EntityBaseResponse
{
    private readonly IAuditableRepository<TEntity> _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<TEntity> _validator;

    public AuditableService
        (
            IAuditableRepository<TEntity> repository
            , IMapper mapper
            , IValidator<TEntity> validator
        ) : base(repository, mapper, validator)
    {
        _repository = repository;
        _mapper = mapper;
        _validator = validator;
    }

    public override async Task<ResponseData<TResponse>> UpdateAsync(long id, TEntity entity)
    {
        var retrievedEntity = await ValidateEntityExistanceById(id);
        entity.IsActive = retrievedEntity.IsActive;
        entity.CreatedBy = retrievedEntity.CreatedBy;
        entity.CreatedDate = retrievedEntity.CreatedDate;

        var validationResult = _validator.Validate(entity);

        if (!validationResult.IsValid)
            return new ResponseDataHandler().Validation<TResponse>(validationResult);

        entity.Id = id;
        await _repository.UpdateAsync(entity);

        return new ResponseDataHandler().Ok<TResponse>();
    }

    #region Private methods

    private async Task<TEntity> ValidateEntityExistanceById(long? id)
    {
        CheckIfNull(id);

        var entity = await _repository.GetAsync(id!.Value);

        CheckIfNull(entity, id);

        return entity!;
    }

    #endregion
}