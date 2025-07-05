namespace App.DataAccess.Entites
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Discount { get; set; }
        public double Rating { get; set; }
        public double Price { get; set; }
        public string Brand { get; set; } = string.Empty;
        public bool IsFavorite { get; set; }
        public string[] Categories { get; set; }
        public bool IsHidden { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ChangedDate { get; set; }
        public string ImgUrl { get; set; } = string.Empty;
        public string ImgPreviewUrl { get; set; } = string.Empty;
        public string? ImgId { get; set; }
    }
}
