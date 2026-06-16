using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ECommercePlatform.Data;

namespace ECommercePlatform.Controllers;

public class HomeController : Controller
{
    private readonly ECommerceDbContext _context;
    
    public HomeController(ECommerceDbContext context)
    {
        _context = context;
    }
    
    public async Task<IActionResult> Index()
    {
        // Get featured products 
        var featuredProducts = await _context.Products
            .Include(p => p.Category)
            .OrderByDescending(p => p.CreatedDate)
            .Take(6)
            .ToListAsync();
            
        // Get all categories 
        var categories = await _context.Categories.ToListAsync();
        
        ViewBag.Categories = categories;
        return View(featuredProducts);
    }
    
}