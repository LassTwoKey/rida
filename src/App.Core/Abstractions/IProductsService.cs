using App.Core.Models;

namespace App.Core.Abstractions
{
    public interface IProductsService
    {
        Task<Guid> CreateProduct(Product product);
        Task<Guid> DeleteProduct(Guid id);
        Task<List<Product>> GetAllProducts();
        Task<Product?> GetProductById(Guid id);
        Task<Guid> UpdateProduct(Guid id, string title, string description, bool onSale, double rating, double price, string brand, bool isFavorite, string[] categories, bool isHidden);
    }
}