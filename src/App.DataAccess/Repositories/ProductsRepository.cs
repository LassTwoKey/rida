using Microsoft.EntityFrameworkCore;
using App.Core.Abstractions;
using App.Core.Models;
using App.DataAccess.Entites;

namespace App.DataAccess.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly AppDbContext _context;

        private async Task UpdateProductCategoriesAsync(ProductEntity product, ICollection<Category> newCategories)
        {
            if (newCategories == null || newCategories.Count == 0)
            {
                // Если список пуст или null — удаляем все категории
                product.Categories.Clear();
                return;
            }

            // Получаем ID всех категорий из входного списка
            var requestedCategoryIds = newCategories.Select(c => c.Id).ToList();

            // Находим только те, которые реально существуют в БД
            var existingValidCategoryIds = await _context.Categories
                .Where(c => requestedCategoryIds.Contains(c.Id))
                .Select(c => c.Id)
                .ToListAsync();

            // Текущие категории у продукта
            var currentCategoryIds = product.Categories.Select(c => c.Id).ToList();

            // Удаляем категории, которых больше нет в списке (даже если они были)
            var toRemove = product.Categories
                .Where(c => !existingValidCategoryIds.Contains(c.Id))
                .ToList();
            foreach (var category in toRemove)
            {
                product.Categories.Remove(category);
            }

            // Добавляем только существующие и ещё не привязанные категории
            var toAdd = existingValidCategoryIds
                .Where(id => !currentCategoryIds.Contains(id))
                .Select(id => new CategoryEntity { Id = id })
                .ToList();

            foreach (var category in toAdd)
            {
                _context.Attach(category); // говорим EF: "это существующая сущность"
                product.Categories.Add(category);
            }
        }

        public ProductsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> Get()
        {
            var productEntities = await _context.Products
                .Include(p => p.Categories)
                .AsNoTracking().ToListAsync();

            var products = productEntities
                .Select(p => Product.Create(
                    p.Id,
                    p.Title,
                    p.Description,
                    p.OnSale,
                    p.Rating,
                    p.Price,
                    p.Brand,
                    p.IsFavorite,
                    [.. p.Categories.Select(c => Category.Create(c.Id, c.Title, c.Description).category)],
                    p.IsHidden
                ).product).ToList();

            return products;
        }

        public async Task<Product?> GetById(Guid id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);


            if (product != null)
            {
                var categories = product.Categories.Select(c => Category.Create(
                    c.Id, c.Title, c.Description).category).ToList();

                return Product.Create(
                    product.Id,
                    product.Title,
                    product.Description,
                    product.OnSale,
                    product.Rating,
                    product.Price,
                    product.Brand,
                    product.IsFavorite,
                    categories,
                    product.IsHidden
                ).product;
            }

            return null;
        }

        public async Task<Guid> Create(Product product)
        {
            var categories = product.Categories.Select(c => new CategoryEntity() {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description
            }).ToList();

            var productEntity = new ProductEntity
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                OnSale = product.OnSale,
                Rating = product.Rating,
                Price = product.Price,
                EstimatedDeliveryDate = product.EstimatedDeliveryDate,
                Brand = product.Brand,
                IsFavorite = product.IsFavorite,
                Categories = categories,
                IsHidden = product.IsHidden
            };

            await _context.Products.AddAsync(productEntity);
            await _context.SaveChangesAsync();

            return productEntity.Id;
        }

        public async Task<Guid> Update(
            Guid id,
            string title,
            string description,
            bool onSale,
            double rating,
            double price,
            string brand,
            bool isFavorite,
            ICollection<Category> categories,
            bool isHidden
        )
        {
            var product = await _context.Products
                .Include(p => p.Categories)
                .FirstOrDefaultAsync() ?? throw new KeyNotFoundException($"Product with ID {id} not found.");

            product.Title = title;
            product.Description = description;
            product.OnSale = onSale;
            product.Rating = rating;
            product.Price = price;
            product.Brand = brand;
            product.IsFavorite = isFavorite;
            product.IsHidden = isHidden;

            await UpdateProductCategoriesAsync(product, categories);

            await _context.SaveChangesAsync();

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Products
                .Where(p => p.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }
    }
}

