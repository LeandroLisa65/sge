using Application.Services;
using Application.Services.Interfaces;
using Contract.Requests;
using Contract.Responses;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Response;

namespace UI.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyController : ControllerBase
{
    private readonly IAuditableService<Company, CompanyResponse> _service;
    private readonly IRequestMapperService<CompanyRequest, Company> _mappingService;

    public CompanyController
        (
            IAuditableService<Company,CompanyResponse> service
            , IRequestMapperService<CompanyRequest, Company> mappingService
        )
    {
        _service = service;
        _mappingService = mappingService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IResult> Get()
    {
        var result = await _service.GetAllAsync();
        return new EndpointResult().GetEndpointResult(result);
    }
    
    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IResult> Get
        (
            long id
        )
    {
        var result = await _service.GetAsync(id);
        return new EndpointResult().GetEndpointResult(result);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IResult> Post
        (
            CompanyRequest companyRequest
        )
    {
        var entity = await _mappingService.MapToEntityAsync(companyRequest);
        var result = await _service.AddAsync(entity);

        return new EndpointResult().GetEndpointResult(result);
    }
    
    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IResult> Put
    (
        long id
        , CompanyRequest companyRequest
    )
    {
        var entity = await _mappingService.MapToEntityAsync(companyRequest);
        var result = await _service.UpdateAsync(id, entity);

        return new EndpointResult().GetEndpointResult(result);
    }
    
    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IResult> Delete
    (
        long id
    )
    {
        var result = await _service.DeleteAsync(id);

        return new EndpointResult().GetEndpointResult(result);
    }
}