using Microsoft.AspNetCore.Mvc;
using ECommercePlatform.Models;
using ECommercePlatform.Services.Interfaces;

namespace ECommercePlatform.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return View(categories);
    }

    public async Task<IActionResult> Details(int id)
    {
        var category = await _categoryService.GetCategoryWithProductsAsync(id);
        if (category == null) return NotFound();
        return View(category);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Category category)
    {
        if (ModelState.IsValid)
        {
            await _categoryService.CreateCategoryAsync(category);
            TempData["Success"] = $"Category '{category.Name}' created successfully!";
            return RedirectToAction(nameof(Index));
        }
        return View(category);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category == null) return NotFound();
        return View(category);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Category category)
    {
        if (id != category.Id) return NotFound();

        if (ModelState.IsValid)
        {
            await _categoryService.UpdateCategoryAsync(category);
            TempData["Success"] = $"Category '{category.Name}' updated successfully!";
            return RedirectToAction(nameof(Index));
        }
        return View(category);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var category = await _categoryService.GetCategoryWithProductsAsync(id);
        if (category == null) return NotFound();
        return View(category);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (await _categoryService.CategoryHasProductsAsync(id))
        {
            TempData["Error"] = "Cannot delete category that has products!";
            return RedirectToAction(nameof(Index));
        }

        await _categoryService.DeleteCategoryAsync(id);
        TempData["Success"] = "Category deleted successfully!";
        return RedirectToAction(nameof(Index));
    }
}
