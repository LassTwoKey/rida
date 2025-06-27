namespace App.DataAccess.Entites
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool OnSale { get; set; }
        public double Rating { get; set; }
        public double Price { get; set; }
        public DateTimeOffset EstimatedDeliveryDate { get; set; }
        public string Brand { get; set; } = string.Empty;
        public bool IsFavorite { get; set; }
        public string[] Categories { get; set; }
        public bool IsHidden { get; set; }
    }
}
