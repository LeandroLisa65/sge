using System.Linq.Expressions;
using Application.Common.Persistance.Repositories;
using ATC.Domain.Exceptions;
using AutoMapper;
using Contract.Entities;
using Domain.Entities;
using FluentValidation;
using Response;

namespace Application.Services;

public class BaseService<TEntity,TResponse> : IBaseService<TEntity,TResponse>
    where TEntity : EntityBase
    where TResponse : EntityBaseResponse
{
    private readonly IEntityBaseRepository<TEntity> _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<TEntity> _validator;
    
    public BaseService
    (
        IEntityBaseRepository<TEntity> repository
        , IMapper mapper
        , IValidator<TEntity> validator
    )
    {
        _repository = repository;
        _mapper = mapper;
        _validator = validator;
    }
    
    public virtual async Task<ResponseData<TResponse>> GetAsync(long? id)
    {
        var entity = await ValidateEntityExistanceById(id);

        var result = _mapper.Map<TEntity, TResponse>(entity);

        return new ResponseDataHandler().Ok(result);
    }

    public virtual async Task<ResponseData<long>> AddAsync(TEntity entity)
    {
        var validationResult = await _validator.ValidateAsync(entity);

        if (!validationResult.IsValid)
            return new ResponseDataHandler().Validation<long>(validationResult);

        var result = await _repository.AddAsync(entity);

        return new ResponseDataHandler().Created(result);
    }

    public virtual async Task<ResponseData<TResponse>> UpdateAsync(long id, TEntity entity)
    {
        var retrievedEntity = await ValidateEntityExistanceById(id);

        var validationResult = _validator.Validate(entity);

        if (!validationResult.IsValid)
            return new ResponseDataHandler().Validation<TResponse>(validationResult);

        await _repository.UpdateAsync(entity);

        return new ResponseDataHandler().Ok<TResponse>();
    }

    public virtual async Task<ResponseData<TResponse>> DeleteAsync(long? id)
    {
        var entity = await ValidateEntityExistanceById(id);
        //entity.LastChangeBy = await _userService.GetUserEmailAsync();

        await _repository.DeleteAsync(entity);

        return new ResponseDataHandler().Ok<TResponse>();
    }

    public async Task<ResponseData<IEnumerable<TResponse>>> GetAllAsync()
    {
        var response = await _repository.GetAllAsync();

        var result = _mapper.Map<IEnumerable<TEntity>, IEnumerable<TResponse>>(response);

        return new ResponseDataHandler().Ok(result);
    }

    public async Task<ResponseData<TResponse>> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = await ValidateEntityExistanceByPredicate(predicate);

        var result = _mapper.Map<TEntity, TResponse>(entity);

        return new ResponseDataHandler().Ok(result);
    }

    public async Task<ResponseData<IEnumerable<TResponse>>> GetManyAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entities = await _repository.GetManyAsync(predicate);

        var result = _mapper.Map<IEnumerable<TEntity>, IEnumerable<TResponse>>(entities);

        return new ResponseDataHandler().Ok(result);
    }

    protected async Task<TEntity> ValidateEntityExistanceByPredicate(Expression<Func<TEntity, bool>> filters)
    {
        var entity = await _repository.GetAsync(filters);

        CheckIfNull(entity);

        return entity!;
    }

    #region Private methods

    private async Task<TEntity> ValidateEntityExistanceById(long? id)
    {
        CheckIfNull(id);

        var entity = await _repository.GetAsync(id!.Value);

        CheckIfNull(entity, id);

        return entity!;
    }

    private protected static void CheckIfNull(long? id)
    {
        if (id is null)
            throw new ArgumentNullException($"Parameter {nameof(id)} cannot be null");
    }

    private protected static void CheckIfNull(TEntity? entity, long? id)
    {
        if (entity is null)
            throw new NotFoundException($"Entity of type {typeof(TEntity).Name} with id {id} could not be found");
    }

    private protected static void CheckIfNull(TEntity? entity)
    {
        if (entity is null)
            throw new NotFoundException($"Entity {typeof(TEntity).Name} not found");
    }
    
    #endregion
}