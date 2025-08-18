namespace App.Application.Contracts
{
    public record CategoriesResponse(
        Guid Id,
        string Title,
        string? Description);

    public record CategoriesRequest(
        string Title,
        string? Description);
}
