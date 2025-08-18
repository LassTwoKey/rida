using App.Core.Abstractions;
using App.Core.Models;
using App.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;

namespace App.DataAccess.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly AppDbContext _context;

        public CategoriesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> Get()
        {
            var categoryEntities = await _context.Categories
                .AsNoTracking().ToListAsync();

            var categories = categoryEntities
                .Select(c => Category.Create(
                    c.Id,
                    c.Title,
                    c.Description
                ).category).ToList();

            return categories;
        }

        public async Task<Category?> GetById(Guid id)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id);

            return category == null
                ? null
                : Category.Create(
                    category.Id,
                    category.Title,
                    category.Description
                ).category;
        }

        public async Task<Guid> Create(Category category)
        {
            var categoryEntity = new CategoryEntity
            {
                Id = category.Id,
                Title = category.Title,
                Description = category.Description,
            };

            await _context.Categories.AddAsync(categoryEntity);
            await _context.SaveChangesAsync();

            return categoryEntity.Id;
        }

        public async Task<Guid> Update(
            Guid id,
            string title,
            string? description)
        {
            await _context.Categories
                .Where(c => c.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(c => c.Title, title)
                    .SetProperty(c => c.Description, description)
                );

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Categories
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
