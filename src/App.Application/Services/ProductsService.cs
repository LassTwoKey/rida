using App.Core.Abstractions;
using App.Core.Models;

namespace App.Application.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productsRepository.Get();
        }

        public async Task<Guid> CreateProduct(Product product)
        {
            return await _productsRepository.Create(product);
        }

        public async Task<Guid> UpdateProduct(
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
            return await _productsRepository.Update(
                id,
                title,
                description,
                onSale,
                rating,
                price,
                estimatedDeliveryDate,
                brand,
                isFavorite,
                categories,
                isHidden
            );
        }

        public async Task<Guid> DeleteProduct(Guid id)
        {
            return await _productsRepository.Delete(id);
        }
    }
}
