using FactoryX.Application.DTOs;
using FactoryX.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FactoryX.Web.Controllers;

[Authorize]
public class ProductionRecordController : Controller
{
    private readonly IProductionRecordService _productionRecordService;
    private readonly IWorkOrderService _workOrderService;
    private readonly IOperatorService _operatorService;

    public ProductionRecordController(IProductionRecordService productionRecordService, IWorkOrderService workOrderService, IOperatorService operatorService)
    {
        _productionRecordService = productionRecordService;
        _workOrderService = workOrderService;
        _operatorService = operatorService;
    }

    public async Task<IActionResult> Index()
    {
        var records = await _productionRecordService.GetAllAsync();
        return View(records);
    }

    public async Task<IActionResult> Details(int id)
    {
        var record = await _productionRecordService.GetByIdAsync(id);
        if (record == null) return NotFound();
        return View(record);
    }

    public async Task<IActionResult> Create()
    {
        await PopulateDropdowns();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductionRecordDto dto)
    {
        if (!ModelState.IsValid)
        {
            await PopulateDropdowns();
            return View(dto);
        }
        await _productionRecordService.CreateAsync(dto);
        TempData["Success"] = "Üretim kaydı başarıyla eklendi.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var record = await _productionRecordService.GetByIdAsync(id);
        if (record == null) return NotFound();
        await PopulateDropdowns();
        return View(record);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ProductionRecordDto dto)
    {
        if (id != dto.Id) return BadRequest();
        if (!ModelState.IsValid)
        {
            await PopulateDropdowns();
            return View(dto);
        }
        await _productionRecordService.UpdateAsync(dto);
        TempData["Success"] = "Üretim kaydı başarıyla güncellendi.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var record = await _productionRecordService.GetByIdAsync(id);
        if (record == null) return NotFound();
        return View(record);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _productionRecordService.DeleteAsync(id);
        TempData["Success"] = "Üretim kaydı başarıyla silindi.";
        return RedirectToAction(nameof(Index));
    }

    private async Task PopulateDropdowns()
    {
        var workOrders = await _workOrderService.GetAllAsync();
        var operators = await _operatorService.GetAllAsync();
        ViewBag.WorkOrders = new SelectList(workOrders, "Id", "Id");
        ViewBag.Operators = new SelectList(operators, "Id", "Name");
    }
}