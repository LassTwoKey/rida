namespace App.Api.Contracts
{
    public record ProductsResponse(
        Guid Id,
        string Title,
        string Description,
        int Discount,
        double Rating,
        double Price,
        DateTimeOffset EstimatedDeliveryDate,
        string Brand,
        bool IsFavorite,
        string[] Categories,
        DateTime CreatedDate,
        DateTime ChangedDate,
        string ImgUrl,
        string ImgPreviewUrl,
        string? ImgId);

    public record ProductsRequest(
        string Title,
        string Description,
        int Discount,
        double Rating,
        double Price,
        string Brand,
        bool IsFavorite,
        string[] Categories,
        bool IsHidden,
        IFormFile? ImageFile = null
        );
}
