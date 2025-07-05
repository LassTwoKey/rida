namespace App.Core.Models
{
    public class Product
    {
        public const int MAX_TITLE_LENGTH = 100;
        public const int MAX_DESCRIPTION_LENGTH = 250;
        public const int MAX_RATING = 5;

        private Product(
            Guid id,
            string title,
            string description,
            int discount,
            double rating,
            double price,
            string brand,
            bool isFavorite,
            string[] categories,
            bool isHidden,
            DateTime changedDate,
            DateTime createdDate,
            string imgUrl,
            string imgPreviewUrl,
            string? imgId)
        {
            Id = id;
            Title = title;
            Description = description;
            Discount = discount;
            Rating = rating;
            Price = price;
            Brand = brand;
            IsFavorite = isFavorite;
            Categories = categories;
            IsHidden = isHidden;
            CreatedDate = createdDate;
            ChangedDate = changedDate;
            ImgUrl = imgUrl;
            ImgPreviewUrl = imgPreviewUrl;
            ImgId = imgId;
        }

        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public int Discount { get; }
        public double Rating { get; }
        public double Price { get; }
        public string Brand { get; } = string.Empty;
        public bool IsFavorite { get; }
        public string[] Categories { get; }
        public bool IsHidden { get; }
        public DateTime CreatedDate { get; set; }
        public DateTime ChangedDate { get; set; }
        public string ImgUrl { get; }
        public string ImgPreviewUrl { get; }
        public string? ImgId { get; }

        public static (Product product, string Error) Create(
            Guid id,
            string title,
            string description,
            int discount,
            double rating,
            double price,
            string brand,
            bool isFavorite,
            string[] categories,
            bool isHidden,
            DateTime createdDate,
            DateTime changedDate,
            string imgUrl,
            string imgPreviewUrl,
            string? imgId)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            {
                error = $"Title can't be empty or longer than ${MAX_TITLE_LENGTH} symbols";
            }
            if (string.IsNullOrEmpty(description) || description.Length > MAX_DESCRIPTION_LENGTH)
            {
                error = $"Description can't be empty or longer than ${MAX_DESCRIPTION_LENGTH} symbols";
            }
            if (rating < 0 || rating > MAX_RATING)
            {
                error = $"Rating can't be lower than 0 or than higher ${MAX_RATING}";
            }
            if (price < 0)
            {
                error = $"Price can't be negative";
            }

            var newPoduct = new Product(
                id,
                title,
                description,
                discount,
                rating,
                price,
                brand,
                isFavorite,
                categories,
                isHidden,
                createdDate,
                changedDate,
                imgUrl,
                imgPreviewUrl,
                imgId
            );

            return (newPoduct, error);
        }
    }
}
