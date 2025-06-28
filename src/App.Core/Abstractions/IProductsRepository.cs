using App.Core.Models;

namespace App.Core.Abstractions
{
    public interface IProductsRepository
    {
        Task<Guid> Create(Product product);
        Task<Guid> Delete(Guid id);
        Task<List<Product>> Get();
        Task<Guid> Update(Guid id, string title, string description, bool onSale, double rating, double price, DateTimeOffset estimatedDeliveryDate, string brand, bool isFavorite, string[] categories, bool isHidden);
    }
}