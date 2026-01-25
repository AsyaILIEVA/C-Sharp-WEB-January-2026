namespace BookShelf.Common
{
    public static class EntityValidation
    {
        // Author
        public const int AuthorNameMinLength = 2;
        public const int AuthorNameMaxLength = 100;
        public const int AuthorCountryMinLength = 2;
        public const int AuthorCountryMaxLength = 150;

        // Book
        public const int BookTitleMinLength = 1;
        public const int BookTitleMaxLength = 200;

    }
}
