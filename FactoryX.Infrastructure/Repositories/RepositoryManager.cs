using FactoryX.Infrastructure.Contracts;

namespace FactoryX.Infrastructure.Repositories;

public class RepositoryManager : IRepositoryManager
{
	public IMachineRepository _machineRepository;
	public IOperatorRepository _operatorRepository;
	public IWorkOrderRepository _workOrderRepository;
	public IShiftRepository _shiftRepository;

	public RepositoryManager(
		IMachineRepository machineRepository,
		IOperatorRepository operatorRepository,
		IWorkOrderRepository workOrderRepository,
		IShiftRepository shiftRepository)
	{
		_machineRepository = machineRepository;
		_operatorRepository = operatorRepository;
		_workOrderRepository = workOrderRepository;
		_shiftRepository = shiftRepository;
	}

	public IMachineRepository MachineRepository => _machineRepository;
	public IOperatorRepository OperatorRepository => _operatorRepository;
	public IWorkOrderRepository WorkOrderRepository => _workOrderRepository;
	public IShiftRepository ShiftRepository => _shiftRepository;
}
