namespace App.Core.Models
{
    public class Category
    {
        public const int MAX_TITLE_LENGTH = 50;
        public const int MAX_DESCRIPTION_LENGTH = 250;

        private Category(Guid id, string title, string? description)
        {
            Id = id;
            Title = title;
            Description = description;
        }

        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public string? Description { get; }

        public static (Category category, string Error) Create(Guid id, string title, string? description)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            {
                error = $"Title can't be empty or longer than ${MAX_TITLE_LENGTH} symbols";
            }
            if (!string.IsNullOrEmpty(description) || description?.Length > MAX_DESCRIPTION_LENGTH)
            {
                error = $"Description can't be empty or longer than ${MAX_DESCRIPTION_LENGTH} symbols";
            }

            var newCategory = new Category(id, title, description);

            return (newCategory, error);
        }
    }
}
