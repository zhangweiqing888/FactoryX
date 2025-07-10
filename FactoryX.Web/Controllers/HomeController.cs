using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FactoryX.Web.Models;
using Microsoft.AspNetCore.Authorization;
using FactoryX.Application.Services;

namespace FactoryX.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMachineService _machineService;
    private readonly IProductService _productService;
    private readonly IWorkOrderService _workOrderService;
    private readonly IOperatorService _operatorService;
    private readonly IProductionRecordService _productionRecordService;
    private readonly IShiftService _shiftService;

    public HomeController(
        ILogger<HomeController> logger,
        IMachineService machineService,
        IProductService productService,
        IWorkOrderService workOrderService,
        IOperatorService operatorService,
        IProductionRecordService productionRecordService,
        IShiftService shiftService)
    {
        _logger = logger;
        _machineService = machineService;
        _productService = productService;
        _workOrderService = workOrderService;
        _operatorService = operatorService;
        _productionRecordService = productionRecordService;
        _shiftService = shiftService;
    }

    public async Task<IActionResult> Index()
    {
        var model = new DashboardViewModel
        {
            MachineCount = (await _machineService.GetAllAsync()).Count(),
            ProductCount = (await _productService.GetAllAsync()).Count(),
            OperatorCount = (await _operatorService.GetAllAsync()).Count(),
            WorkOrderCount = (await _workOrderService.GetAllAsync()).Count(),
            ProductionRecordCount = (await _productionRecordService.GetAllAsync()).Count(),
            ShiftCount = (await _shiftService.GetAllAsync()).Count(),
            RecentWorkOrders = (await _workOrderService.GetAllAsync()).OrderByDescending(x => x.StartDate).Take(5).ToList(),
            RecentProductionRecords = (await _productionRecordService.GetAllAsync()).OrderByDescending(x => x.Timestamp).Take(5).ToList()
        };
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [Authorize]
    public async Task<IActionResult> Dashboard()
    {
        ViewBag.MachineCount = (await _machineService.GetAllAsync()).Count();
        ViewBag.ProductCount = (await _productService.GetAllAsync()).Count();
        ViewBag.WorkOrderCount = (await _workOrderService.GetAllAsync()).Count();
        ViewBag.OperatorCount = (await _operatorService.GetAllAsync()).Count();
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
