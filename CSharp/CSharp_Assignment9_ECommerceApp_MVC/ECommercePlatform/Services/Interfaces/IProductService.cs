using ECommercePlatform.Models;
using ECommercePlatform.ViewModels;

namespace ECommercePlatform.Services.Interfaces;

public interface IProductService
{
    Task<List<ProductIndexViewModel>> GetProductsAsync(int? categoryId);
    Task<ProductDetailsViewModel?> GetProductDetailsAsync(int id);
    Task<Product?> GetProductByIdAsync(int id);
    Task<bool> CreateProductAsync(ProductCreateViewModel viewModel);
    Task<bool> UpdateProductAsync(int id, ProductEditViewModel viewModel);
    Task<bool> DeleteProductAsync(int id);
    Task<bool> ProductExistsAsync(int id);
}
