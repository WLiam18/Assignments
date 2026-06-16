using ECommercePlatform.Models;
using ECommercePlatform.Repositories.Interfaces;
using ECommercePlatform.Services.Interfaces;

namespace ECommercePlatform.Services.Implementations;
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<Category>> GetAllCategoriesAsync()
    {
        return await _categoryRepository.GetAllAsync();
    }

    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        return await _categoryRepository.GetByIdAsync(id);
    }

    public async Task<Category?> GetCategoryWithProductsAsync(int id)
    {
        return await _categoryRepository.GetByIdWithProductsAsync(id);
    }

    public async Task<bool> CreateCategoryAsync(Category category)
    {
        category.CreatedDate = DateTime.Now;
        await _categoryRepository.AddAsync(category);
        return true;
    }

    public async Task<bool> UpdateCategoryAsync(Category category)
    {
        var existing = await _categoryRepository.GetByIdAsync(category.Id);
        if (existing == null) return false;

        existing.Name = category.Name;
        existing.Description = category.Description;

        await _categoryRepository.UpdateAsync(existing);
        return true;
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        if (category == null) return false;

        await _categoryRepository.DeleteAsync(category);
        return true;
    }

    public async Task<bool> CategoryHasProductsAsync(int id)
    {
        return await _categoryRepository.HasProductsAsync(id);
    }
}
