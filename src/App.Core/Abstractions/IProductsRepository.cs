using App.Core.Models;

namespace App.Core.Abstractions
{
    public interface IProductsRepository
    {
        Task<Guid> Create(Product product);
        Task<Guid> Delete(Guid id);
        Task<List<Product>> Get();
        Task<Product?> GetById(Guid id);
        Task<Guid> Update(Guid id, string title, string description, bool onSale, double rating, double price, string brand, bool isFavorite, string[] categories, bool isHidden);
    }
}