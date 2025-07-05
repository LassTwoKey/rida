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

        public async Task<Product?> GetProductById(Guid id)
        {
            return await _productsRepository.GetById(id);
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
            return await _productsRepository.Update(
                id,
                title,
                description,
                discount,
                rating,
                price,
                brand,
                isFavorite,
                categories,
                isHidden,
                changedDate,
                imgUrl,
                imgPreviewUrl,
                imgId
            );
        }

        public async Task<Guid> DeleteProduct(Guid id)
        {
            return await _productsRepository.Delete(id);
        }
    }
}
