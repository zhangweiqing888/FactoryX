namespace FactoryX.Application.DTOs.Requests.MachineRequests;

public sealed record UpdateMachineRequest(
    string Name,
    string Status,
    int Capacity
);