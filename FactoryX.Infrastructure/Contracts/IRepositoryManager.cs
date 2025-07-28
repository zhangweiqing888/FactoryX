namespace FactoryX.Infrastructure.Contracts;

public interface IRepositoryManager
{
    IMachineRepository MachineRepository { get; }
    IOperatorRepository OperatorRepository { get; }
    IWorkOrderRepository WorkOrderRepository { get; }
    IShiftRepository ShiftRepository { get; }
    IDowntimeRepository DowntimeRepository { get; }
    IUserRepository UserRepository { get; }
    Task SaveAsync();
}