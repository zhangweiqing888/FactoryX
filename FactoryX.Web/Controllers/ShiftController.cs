using FactoryX.Application.DTOs;
using FactoryX.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FactoryX.Web.Controllers;

[Authorize]
public class ShiftController : Controller
{
    private readonly IShiftService _shiftService;

    public ShiftController(IShiftService shiftService)
    {
        _shiftService = shiftService;
    }

    public async Task<IActionResult> Index()
    {
        var shifts = await _shiftService.GetAllAsync();
        return View(shifts);
    }

    public async Task<IActionResult> Details(int id)
    {
        var shift = await _shiftService.GetByIdAsync(id);
        if (shift == null) return NotFound();
        return View(shift);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ShiftDto dto)
    {
        if (!ModelState.IsValid) return View(dto);
        await _shiftService.CreateAsync(dto);
        TempData["Success"] = "Vardiya başarıyla eklendi.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var shift = await _shiftService.GetByIdAsync(id);
        if (shift == null) return NotFound();
        return View(shift);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ShiftDto dto)
    {
        if (id != dto.Id) return BadRequest();
        if (!ModelState.IsValid) return View(dto);
        await _shiftService.UpdateAsync(dto);
        TempData["Success"] = "Vardiya başarıyla güncellendi.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var shift = await _shiftService.GetByIdAsync(id);
        if (shift == null) return NotFound();
        return View(shift);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _shiftService.DeleteAsync(id);
        TempData["Success"] = "Vardiya başarıyla silindi.";
        return RedirectToAction(nameof(Index));
    }
}