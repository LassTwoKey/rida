namespace App.Core.Models
{
    public class Category
    {
        public const int MAX_TITLE_LENGTH = 50;

        private Category(Guid id, string title)
        {
            Id = id;
            Title = title;
        }

        public Guid Id { get; }
        public string Title { get; } = string.Empty;

        public static (Category category, string Error) Create(Guid id, string title)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            {
                error = $"Title can't be empty or longer than ${MAX_TITLE_LENGTH} symbols";
            }

            var newPoduct = new Category(id, title);

            return (newPoduct, error);
        }
    }
}
