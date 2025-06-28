using App.Core.Models;

namespace App.Api.Contracts
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
        string[] Categories);

    public record ProductsRequest(
        string Title,
        string Description,
        bool OnSale,
        double Rating,
        double Price,
        DateTimeOffset EstimatedDeliveryDate,
        string Brand,
        bool IsFavorite,
        string[] Categories,
        bool IsHidden);
}
