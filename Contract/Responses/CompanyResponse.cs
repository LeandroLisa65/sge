using Contract.Entities;

namespace Contract.Responses;

public record CompanyResponse : EntityBaseResponse
{
    public CompanyResponse
        (
            long Id
        ) : base(Id)
    {
        
    }
    public string? Name { get; set; }
}