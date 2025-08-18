using App.Core.Models;

namespace App.Application.Contracts
{
    public record ProductsResponse(
        Guid Id,
        string Title,
        string Description,
        bool OnSale,
        double Rating,
        double Price,
        DateTimeOffset EstimatedDeliveryDate,
        string Brand,
        bool IsFavorite,
        List<CategoriesResponse> Categories);

    public record ProductsRequest(
        string Title,
        string Description,
        bool OnSale,
        double Rating,
        double Price,
        string Brand,
        bool IsFavorite,
        List<CategoriesResponse> Categories,
        bool IsHidden);
}
