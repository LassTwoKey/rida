using App.Core.Abstractions;
using App.Core.Models;

namespace App.Application.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<Category?> GetCategoryById(Guid id)
        {
            return await _categoriesRepository.GetById(id);
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _categoriesRepository.Get();
        }

        public async Task<Guid> CreateCategory(Category category)
        {
            return await _categoriesRepository.Create(category);
        }

        public async Task<Guid> UpdateCategory(
            Guid id,
            string title,
            string? description)
        {
            return await _categoriesRepository.Update(
                id,
                title,
                description);
        }

        public async Task<Guid> DeleteCategory(Guid id)
        {
            return await _categoriesRepository.Delete(id);
        }
    }
}
