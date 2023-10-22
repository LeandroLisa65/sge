using AutoMapper;
using Contract.Requests;
using Contract.Responses;
using Domain.Entities;

namespace Application.Mappers;

public class CompanyMappingProfile : Profile
{
    public CompanyMappingProfile()
    {
        CreateMap<Company, CompanyResponse>(); 
        CreateMap<CompanyRequest, Company>().ReverseMap();
    }
}