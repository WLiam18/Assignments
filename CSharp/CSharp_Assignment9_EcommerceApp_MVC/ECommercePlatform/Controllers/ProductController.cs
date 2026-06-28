using Microsoft.AspNetCore.Mvc;
using ECommercePlatform.Models;
using ECommercePlatform.Services.Interfaces;
using ECommercePlatform.ViewModels;

namespace ECommercePlatform.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public ProductController(IProductService productService, ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    public async Task<IActionResult> Index(int? categoryId)
    {
        var products = await _productService.GetProductsAsync(categoryId);
        ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();
        return View(products);
    }

    public async Task<IActionResult> Details(int id)
    {
        var product = await _productService.GetProductDetailsAsync(id);
        if (product == null) return NotFound();
        return View(product);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductCreateViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            await _productService.CreateProductAsync(viewModel);
            TempData["Success"] = "Product added successfully!";
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();
        return View(viewModel);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null) return NotFound();

        var viewModel = new ProductEditViewModel
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            StockQuantity = product.StockQuantity,
            ImageUrl = product.ImageUrl,
            CategoryId = product.CategoryId
        };

        ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ProductEditViewModel viewModel)
    {
        if (id != viewModel.Id) return NotFound();

        if (ModelState.IsValid)
        {
            await _productService.UpdateProductAsync(id, viewModel);
            TempData["Success"] = "Product updated successfully!";
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();
        return View(viewModel);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null) return NotFound();

        var viewModel = new ProductDeleteViewModel
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            CategoryName = product.Category?.Name ?? "Uncategorized",
            ImageUrl = product.ImageUrl
        };

        return View(viewModel);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _productService.DeleteProductAsync(id);
        TempData["Success"] = "Product deleted successfully!";
        return RedirectToAction(nameof(Index));
    }
}
