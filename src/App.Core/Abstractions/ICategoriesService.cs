using App.Core.Models;

namespace App.Core.Abstractions
{
    public interface ICategoriesService
    {
        Task<Guid> CreateCategory(Category category);
        Task<Guid> DeleteCategory(Guid id);
        Task<List<Category>> GetAllCategories();
        Task<Category?> GetCategoryById(Guid id);
        Task<Guid> UpdateCategory(Guid id, string title, string? description);
    }
}