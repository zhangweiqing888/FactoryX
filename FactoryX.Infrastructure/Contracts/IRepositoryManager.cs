namespace FactoryX.Infrastructure.Contracts;

public interface IRepositoryManager
{
    IMachineRepository MachineRepository { get; }
    IOperatorRepository OperatorRepository { get; }
    IWorkOrderRepository WorkOrderRepository { get; }
    IShiftRepository ShiftRepository { get; }
}