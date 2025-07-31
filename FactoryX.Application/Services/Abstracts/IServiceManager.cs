using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryX.Application.Services.Abstracts;

public interface IServiceManager
{
	IMachineService MachineService { get; }
	IOperatorService OperatorService { get; }
	IProductionRecordService ProductionRecordService { get; }
	IProductService ProductService { get; }
	IUserService UserService { get; }
	IShiftService ShiftService { get; }
	IWorkOrderService WorkOrderService { get; }
}
