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
            bool onSale,
            double rating,
            double price,
            string brand,
            bool isFavorite,
            string[] categories,
            bool isHidden
        )
        {
            Id = id;
            Title = title;
            Description = description;
            OnSale = onSale;
            Rating = rating;
            Price = price;
            Brand = brand;
            IsFavorite = isFavorite;
            Categories = categories;
            IsHidden = isHidden;
        }

        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public bool OnSale { get; }
        public double Rating { get; }
        public double Price { get; }
        public DateTimeOffset EstimatedDeliveryDate { get; }
        public string Brand { get; } = string.Empty;
        public bool IsFavorite { get; }
        public string[] Categories { get; }
        public bool IsHidden { get; }

        public static (Product product, string Error) Create(
            Guid id,
            string title,
            string description,
            bool onSale,
            double rating,
            double price,
            string brand,
            bool isFavorite,
            string[] categories,
            bool isHidden
        )
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
                onSale,
                rating,
                price,
                brand,
                isFavorite,
                categories,
                isHidden
            );

            return (newPoduct, error);
        }
    }
}
