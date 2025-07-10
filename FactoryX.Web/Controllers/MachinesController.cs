using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FactoryX.Application.Services;
using FactoryX.Application.DTOs;

namespace FactoryX.Web.Controllers;

[Authorize]
public class MachinesController : Controller
{
    private readonly IMachineService _machineService;
    public MachinesController(IMachineService machineService)
    {
        _machineService = machineService;
    }

    public async Task<IActionResult> Index()
    {
        var machines = await _machineService.GetAllAsync();
        return View(machines);
    }

    public async Task<IActionResult> Details(int id)
    {
        var machine = await _machineService.GetByIdAsync(id);
        if (machine == null) return NotFound();
        return View(machine);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MachineDto dto)
    {
        if (!ModelState.IsValid) return View(dto);
        await _machineService.CreateAsync(dto);
        TempData["Success"] = "Machine created successfully.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var machine = await _machineService.GetByIdAsync(id);
        if (machine == null) return NotFound();
        return View(machine);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, MachineDto dto)
    {
        if (id != dto.Id) return BadRequest();
        if (!ModelState.IsValid) return View(dto);
        await _machineService.UpdateAsync(dto);
        TempData["Success"] = "Machine updated successfully.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var machine = await _machineService.GetByIdAsync(id);
        if (machine == null) return NotFound();
        return View(machine);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _machineService.DeleteAsync(id);
        TempData["Success"] = "Machine deleted successfully.";
        return RedirectToAction(nameof(Index));
    }
}