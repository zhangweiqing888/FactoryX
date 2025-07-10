namespace FactoryX.Infrastructure.Contracts;

public interface IRepositoryManager
{
    IMachineRepository MachineRepository { get; }
    IOperatorRepository OperatorRepository { get; }
}