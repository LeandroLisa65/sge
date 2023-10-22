using Contract.Entities;

namespace Contract.Requests;

public record CompanyRequest(long? Id, string Name) : EntityBaseRequest(Id);