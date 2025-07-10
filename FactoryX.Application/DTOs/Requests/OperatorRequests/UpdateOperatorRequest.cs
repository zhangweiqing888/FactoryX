namespace FactoryX.Application.DTOs.Requests.OperatorRequests;

public sealed record UpdateOperatorRequest(
    string Name,
    string EmployeeNumber
);