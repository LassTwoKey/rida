using App.Core.Models;

namespace App.Core.Abstractions
{
    public interface IProductsService
    {
        Task<Guid> CreateProduct(Product product);
        Task<Guid> DeleteProduct(Guid id);
        Task<List<Product>> GetAllProducts();
        Task<Guid> UpdateProduct(Guid id, string title, string description, bool onSale, double rating, double price, DateTimeOffset estimatedDeliveryDate, string brand, bool isFavorite, string[] categories, bool isHidden);
    }
}