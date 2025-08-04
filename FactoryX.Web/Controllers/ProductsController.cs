using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FactoryX.Application.DTOs;
using FactoryX.Application.Services.Abstracts;
using FactoryX.Application.DTOs.Requests.ProductRequests;

namespace FactoryX.Web.Controllers;

[Authorize]
public class ProductsController : Controller
{
    private readonly IServiceManager _serviceManager;
    public ProductsController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
	}

    public async Task<IActionResult> Index()
    {
        var products = await _serviceManager.ProductService.GetAllAsync();
        return View(products);
    }

    public async Task<IActionResult> Details(int id)
    {
        var product = await _serviceManager.ProductService.GetByIdAsync(id);
        if (product == null) return NotFound();
        return View(product);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(InsertProductRequest request)
    {
        if (!ModelState.IsValid) return View(request);
        await _serviceManager.ProductService.CreateAsync(request);
        TempData["Success"] = "Product created successfully.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var product = await _serviceManager.ProductService.GetByIdAsync(id);
        if (product == null) return NotFound();
        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, UpdateProductRequest request)
    {
        if (id != request.Id) return BadRequest();
        if (!ModelState.IsValid) return View(request);
        await _serviceManager.ProductService.UpdateAsync(request);
        TempData["Success"] = "Product updated successfully.";
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var product = await _serviceManager.ProductService.GetByIdAsync(id);
        if (product == null) return NotFound();
        return View(product);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(DeleteProductRequest request)
    {
        await _serviceManager.ProductService.DeleteAsync(request);
        TempData["Success"] = "Product deleted successfully.";
        return RedirectToAction(nameof(Index));
    }
}