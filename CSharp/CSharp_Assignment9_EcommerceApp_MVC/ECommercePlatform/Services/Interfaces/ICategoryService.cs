using ECommercePlatform.Models;
using ECommercePlatform.ViewModels;

namespace ECommercePlatform.Services.Interfaces;

public interface ICategoryService
{
    Task<List<Category>> GetAllCategoriesAsync();
    Task<Category?> GetCategoryByIdAsync(int id);
    Task<Category?> GetCategoryWithProductsAsync(int id);
    Task<bool> CreateCategoryAsync(Category category);
    Task<bool> UpdateCategoryAsync(Category category);
    Task<bool> DeleteCategoryAsync(int id);
    Task<bool> CategoryHasProductsAsync(int id);
}
