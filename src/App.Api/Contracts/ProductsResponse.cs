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
        List<CategoriesResponse> Categories,
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
        List<CategoriesResponse> Categories,
        bool IsHidden,
        FileContent? ImageFile);
}
