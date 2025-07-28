using FactoryX.Application.DTOs;
using FactoryX.Application.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FactoryX.Web.Controllers;

[Authorize]
public class WorkOrderController : Controller
{
    private readonly IWorkOrderService _workOrderService;
    private readonly IProductService _productService;
    private readonly IMachineService _machineService;

    public WorkOrderController(IWorkOrderService workOrderService, IProductService productService, IMachineService machineService)
    {
        _workOrderService = workOrderService;
        _productService = productService;
        _machineService = machineService;
    }

    public async Task<IActionResult> Index()
    {
        var workOrders = await _workOrderService.GetAllAsync();
        return View(workOrders);
    }

    public async Task<IActionResult> Details(int id)
    {
        var wo = await _workOrderService.GetByIdAsync(id);
        if (wo == null) return NotFound();
        return View(wo);
    }

    public async Task<IActionResult> Create()
    {
        await PopulateDropdowns();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(WorkOrderDto dto)
    {
        if (!ModelState.IsValid)
        {
            await PopulateDropdowns();
            return View(dto);
        }
        await _workOrderService.CreateAsync(dto);
        TempData["Success"] = "İş emri başarıyla eklendi.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var wo = await _workOrderService.GetByIdAsync(id);
        if (wo == null) return NotFound();
        await PopulateDropdowns();
        return View(wo);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, WorkOrderDto dto)
    {
        if (id != dto.Id) return BadRequest();
        if (!ModelState.IsValid)
        {
            await PopulateDropdowns();
            return View(dto);
        }
        await _workOrderService.UpdateAsync(dto);
        TempData["Success"] = "İş emri başarıyla güncellendi.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var wo = await _workOrderService.GetByIdAsync(id);
        if (wo == null) return NotFound();
        return View(wo);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _workOrderService.DeleteAsync(id);
        TempData["Success"] = "İş emri başarıyla silindi.";
        return RedirectToAction(nameof(Index));
    }

    private async Task PopulateDropdowns()
    {
        var products = await _productService.GetAllAsync();
        var machines = await _machineService.GetAllAsync();
        ViewBag.Products = new SelectList(products, "Id", "Name");
        ViewBag.Machines = new SelectList(machines, "Id", "Name");
    }
}