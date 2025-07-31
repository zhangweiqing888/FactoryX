using FactoryX.Infrastructure.Contracts;

namespace FactoryX.Infrastructure.Repositories;

public class RepositoryManager : IRepositoryManager
{
	private readonly AppDbContext _context;
	private readonly IMachineRepository _machineRepository;
	private readonly IOperatorRepository _operatorRepository;
	private readonly IWorkOrderRepository _workOrderRepository;
	private readonly IShiftRepository _shiftRepository;
	private readonly IDowntimeRepository _downtimeRepository;
	private readonly IUserRepository _userRepository;
	private readonly IProductRepository _productRepository;
	private readonly IMaterialRepository _materialRepository;
	private readonly IMaterialUsageRepository _materialUsageRepository;
	private readonly IProductionRecordRepository _productionRecordRepository;

	public RepositoryManager(
		AppDbContext context,
		IMachineRepository machineRepository,
		IOperatorRepository operatorRepository,
		IWorkOrderRepository workOrderRepository,
		IShiftRepository shiftRepository,
		IDowntimeRepository downtimeRepository,
		IUserRepository userRepository,
		IProductRepository productRepository,
		IMaterialRepository materialRepository,
		IMaterialUsageRepository materialUsageRepository,
		IProductionRecordRepository productionRecordRepository)
	{
		_context = context;
		_machineRepository = machineRepository;
		_operatorRepository = operatorRepository;
		_workOrderRepository = workOrderRepository;
		_shiftRepository = shiftRepository;
		_downtimeRepository = downtimeRepository;
		_userRepository = userRepository;
		_productRepository = productRepository;
		_materialRepository = materialRepository;
		_materialUsageRepository = materialUsageRepository;
		_productionRecordRepository = productionRecordRepository;
	}

	public IMachineRepository MachineRepository => _machineRepository;
	public IOperatorRepository OperatorRepository => _operatorRepository;
	public IWorkOrderRepository WorkOrderRepository => _workOrderRepository;
	public IShiftRepository ShiftRepository => _shiftRepository;
	public IDowntimeRepository DowntimeRepository => _downtimeRepository;
	public IUserRepository UserRepository => _userRepository;
	public IProductRepository ProductRepository => _productRepository;
	public IMaterialRepository MaterialRepository => _materialRepository;
	public IMaterialUsageRepository MaterialUsageRepository => _materialUsageRepository;
	public IProductionRecordRepository ProductionRecordRepository => _productionRecordRepository;

	public async Task SaveAsync()
	{
		await _context.SaveChangesAsync();
	}
}
