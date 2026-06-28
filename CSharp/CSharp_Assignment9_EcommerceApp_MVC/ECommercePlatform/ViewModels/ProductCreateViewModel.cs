using System.ComponentModel.DataAnnotations;

namespace ECommercePlatform.ViewModels;

public class ProductCreateViewModel
{
    [Required(ErrorMessage = "Product name is required")]
    [MaxLength(200, ErrorMessage = "Name cannot exceed 200 characters")]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(1000)]
    public string? Description { get; set; }
    
    [Required(ErrorMessage = "Price is required")]
    [Range(0.01, 999999.99, ErrorMessage = "Price must be between 0.01 and 999999.99")]
    public decimal Price { get; set; }
    
    [Required(ErrorMessage = "Stock quantity is required")]
    [Range(0, 999999, ErrorMessage = "Stock must be 0 or greater")]
    public int StockQuantity { get; set; }
    
    [Url(ErrorMessage = "Please enter a valid URL")]
    public string? ImageUrl { get; set; }
    
    [Required(ErrorMessage = "Please select a category")]
    public int CategoryId { get; set; }
}