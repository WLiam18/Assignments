using ECommercePlatform.Models;

namespace ECommercePlatform.Repositories.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(int id);
    Task<Category?> GetByIdWithProductsAsync(int id);
    Task AddAsync(Category category);
    Task UpdateAsync(Category category);
    Task DeleteAsync(Category category);
    Task<bool> HasProductsAsync(int categoryId);
    Task<bool> ExistsAsync(int id);
}
