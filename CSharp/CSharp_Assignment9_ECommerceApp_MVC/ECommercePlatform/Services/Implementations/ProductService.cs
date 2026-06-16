using ECommercePlatform.Models;
using ECommercePlatform.Repositories.Interfaces;
using ECommercePlatform.Services.Interfaces;
using ECommercePlatform.ViewModels;

namespace ECommercePlatform.Services.Implementations;
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductIndexViewModel>> GetProductsAsync(int? categoryId)
    {
        List<Product> products;

        if (categoryId.HasValue && categoryId.Value > 0)
        {
            products = await _productRepository.GetByCategoryAsync(categoryId.Value);
        }
        else
        {
            products = await _productRepository.GetAllAsync();
        }

        return products.Select(p => new ProductIndexViewModel
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            Price = p.Price,
            StockQuantity = p.StockQuantity,
            ImageUrl = p.ImageUrl,
            CategoryName = p.Category?.Name ?? "Uncategorized"
        }).ToList();
    }

    public async Task<ProductDetailsViewModel?> GetProductDetailsAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null) return null;

        return new ProductDetailsViewModel
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            StockQuantity = product.StockQuantity,
            ImageUrl = product.ImageUrl,
            CategoryName = product.Category?.Name ?? "Uncategorized",
            CreatedDate = product.CreatedDate
        };
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    public async Task<bool> CreateProductAsync(ProductCreateViewModel viewModel)
    {
        var product = new Product
        {
            Name = viewModel.Name,
            Description = viewModel.Description,
            Price = viewModel.Price,
            StockQuantity = viewModel.StockQuantity,
            ImageUrl = viewModel.ImageUrl,
            CategoryId = viewModel.CategoryId,
            CreatedDate = DateTime.Now
        };

        await _productRepository.AddAsync(product);
        return true;
    }

    public async Task<bool> UpdateProductAsync(int id, ProductEditViewModel viewModel)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null) return false;

        product.Name = viewModel.Name;
        product.Description = viewModel.Description;
        product.Price = viewModel.Price;
        product.StockQuantity = viewModel.StockQuantity;
        product.ImageUrl = viewModel.ImageUrl;
        product.CategoryId = viewModel.CategoryId;

        await _productRepository.UpdateAsync(product);
        return true;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if (product == null) return false;

        await _productRepository.DeleteAsync(product);
        return true;
    }

    public async Task<bool> ProductExistsAsync(int id)
    {
        return await _productRepository.ExistsAsync(id);
    }
}
