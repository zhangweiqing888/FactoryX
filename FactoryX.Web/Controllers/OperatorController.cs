using FactoryX.Application.DTOs;
using FactoryX.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FactoryX.Web.Controllers;

[Authorize]
public class OperatorController : Controller
{
    private readonly IOperatorService _operatorService;

    public OperatorController(IOperatorService operatorService)
    {
        _operatorService = operatorService;
    }

    public async Task<IActionResult> Index()
    {
        var operators = await _operatorService.GetAllAsync();
        return View(operators);
    }

    public async Task<IActionResult> Details(int id)
    {
        var op = await _operatorService.GetByIdAsync(id);
        if (op == null) return NotFound();
        return View(op);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(OperatorDto dto)
    {
        if (!ModelState.IsValid) return View(dto);
        await _operatorService.CreateAsync(dto);
        TempData["Success"] = "Operatör başarıyla eklendi.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var op = await _operatorService.GetByIdAsync(id);
        if (op == null) return NotFound();
        return View(op);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, OperatorDto dto)
    {
        if (id != dto.Id) return BadRequest();
        if (!ModelState.IsValid) return View(dto);
        await _operatorService.UpdateAsync(dto);
        TempData["Success"] = "Operatör başarıyla güncellendi.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var op = await _operatorService.GetByIdAsync(id);
        if (op == null) return NotFound();
        return View(op);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _operatorService.DeleteAsync(id);
        TempData["Success"] = "Operatör başarıyla silindi.";
        return RedirectToAction(nameof(Index));
    }
}