using Microsoft.EntityFrameworkCore;
using App.Core.Abstractions;
using App.Core.Models;
using App.DataAccess.Entites;

namespace App.DataAccess.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly AppDbContext _context;

        public ProductsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> Get()
        {
            var productEntities = await _context.Products
                .AsNoTracking().ToListAsync();

            var products = productEntities
                .Select(p => Product.Create(
                    p.Id,
                    p.Title,
                    p.Description,
                    p.OnSale,
                    p.Rating,
                    p.Price,
                    p.EstimatedDeliveryDate,
                    p.Brand,
                    p.IsFavorite,
                    p.Categories,
                    p.IsHidden
                ).product).ToList();

            return products;
        }

        public async Task<Guid> Create(Product product)
        {
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
                Categories = product.Categories,
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
            DateTimeOffset estimatedDeliveryDate,
            string brand,
            bool isFavorite,
            string[] categories,
            bool isHidden
        )
        {
            await _context.Products
                .Where(p => p.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(p => p.Title, p => p.Title)
                    .SetProperty(p => p.Description, p => p.Title)
                    .SetProperty(p => p.OnSale, p => p.OnSale)
                    .SetProperty(p => p.Rating, p => p.Rating)
                    .SetProperty(p => p.Price, p => p.Price)
                    .SetProperty(p => p.EstimatedDeliveryDate, p => p.EstimatedDeliveryDate)
                    .SetProperty(p => p.Brand, p => p.Brand)
                    .SetProperty(p => p.IsFavorite, p => p.IsFavorite)
                    .SetProperty(p => p.Categories, p => p.Categories)
                    .SetProperty(p => p.IsHidden, p => p.IsHidden)
                );

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

