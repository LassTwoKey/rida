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
                    p.Discount,
                    p.Rating,
                    p.Price,
                    p.Brand,
                    p.IsFavorite,
                    p.Categories,
                    p.IsHidden,
                    p.CreatedDate,
                    p.ChangedDate,
                    p.ImgUrl,
                    p.ImgPreviewUrl,
                    p.ImgId
                ).product).ToList();

            return products;
        }

        public async Task<Product?> GetById(Guid id)
        {
            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            return product == null
                ? null
                : Product.Create(
                    product.Id,
                    product.Title,
                    product.Description,
                    product.Discount,
                    product.Rating,
                    product.Price,
                    product.Brand,
                    product.IsFavorite,
                    product.Categories,
                    product.IsHidden,
                    product.CreatedDate,
                    product.ChangedDate,
                    product.ImgUrl,
                    product.ImgPreviewUrl,
                    product.ImgId).product;
        }

        public async Task<Guid> Create(Product product)
        {
            var productEntity = new ProductEntity
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Discount = product.Discount,
                Rating = product.Rating,
                Price = product.Price,
                Brand = product.Brand,
                IsFavorite = product.IsFavorite,
                Categories = product.Categories,
                IsHidden = product.IsHidden,
                CreatedDate = product.CreatedDate,
                ChangedDate = product.ChangedDate,
                ImgUrl = product.ImgUrl,
                ImgPreviewUrl = product.ImgPreviewUrl,
                ImgId = product.ImgId,
            };

            await _context.Products.AddAsync(productEntity);
            await _context.SaveChangesAsync();

            return productEntity.Id;
        }

        public async Task<Guid> Update(
            Guid id,
            string title,
            string description,
            int discount,
            double rating,
            double price,
            string brand,
            bool isFavorite,
            string[] categories,
            bool isHidden,
            DateTime changedDate,
            string imgUrl,
            string imgPreviewUrl,
            string? imgId
        )
        {
            await _context.Products
                .Where(p => p.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(p => p.Title, title)
                    .SetProperty(p => p.Description, description)
                    .SetProperty(p => p.Discount, discount)
                    .SetProperty(p => p.Rating, rating)
                    .SetProperty(p => p.Price, price)
                    .SetProperty(p => p.Brand, brand)
                    .SetProperty(p => p.IsFavorite, isFavorite)
                    .SetProperty(p => p.Categories, categories)
                    .SetProperty(p => p.IsHidden, isHidden)
                    .SetProperty(p => p.ChangedDate, changedDate)
                    .SetProperty(p => p.ImgUrl, imgUrl)
                    .SetProperty(p => p.ImgPreviewUrl, imgPreviewUrl)
                    .SetProperty(p => p.ImgId, imgId)
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

