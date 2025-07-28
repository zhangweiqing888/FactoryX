using FactoryX.Application.Services.Abstracts;

namespace FactoryX.Application.Services.Concretes;

public sealed class ServiceManager : IServiceManager
{
	private readonly IMachineService _machineService;
	private readonly IOperatorService _operatorService;
	private readonly IProductionRecordService _productionRecordService;
	private readonly IProductService _productService;
	private readonly IUserService _userService;
	private readonly IShiftService _shiftService;
	private readonly IWorkOrderService _workOrderService;

	public ServiceManager(IMachineService machineService, IOperatorService operatorService, IProductionRecordService productionRecordService, IProductService productService, IUserService userService, IShiftService shiftService, IWorkOrderService workOrderService)
	{
		_machineService = machineService;
		_operatorService = operatorService;
		_productionRecordService = productionRecordService;
		_productService = productService;
		_userService = userService;
		_shiftService = shiftService;
		_workOrderService = workOrderService;
	}

	public IMachineService MachineService => _machineService;

	public IOperatorService OperatorService => _operatorService;

	public IProductionRecordService ProductionRecordService => _productionRecordService;

	public IProductService ProductService => _productService;

	public IUserService UserService => _userService;

	public IShiftService ShiftService => _shiftService;

	public IWorkOrderService WorkOrderService => _workOrderService;
}
