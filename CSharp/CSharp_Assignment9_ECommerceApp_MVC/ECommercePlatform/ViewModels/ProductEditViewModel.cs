using System.ComponentModel.DataAnnotations;

namespace ECommercePlatform.ViewModels;

public class ProductEditViewModel
{
    [Required]
    public int Id { get; set; } 
    
    [Required(ErrorMessage = "Product name is required")]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(1000)]
    public string? Description { get; set; }
    
    [Required]
    [Range(0.01, 999999.99)]
    public decimal Price { get; set; }
    
    [Required]
    [Range(0, 999999)]
    public int StockQuantity { get; set; }
    
    [Url]
    public string? ImageUrl { get; set; }
    
    [Required]
    public int CategoryId { get; set; }
}