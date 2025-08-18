using App.Core.Models;

namespace App.Core.Abstractions
{
    public interface ICategoriesRepository
    {
        Task<Guid> Create(Category category);
        Task<Guid> Delete(Guid id);
        Task<List<Category>> Get();
        Task<Category?> GetById(Guid id);
        Task<Guid> Update(Guid id, string title, string? description);
    }
}