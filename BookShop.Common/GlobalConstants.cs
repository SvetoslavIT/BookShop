namespace BookShop.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "BookShop";

        public const string AdministratorRoleName = "Administrator";

        public const int NameMinLength = 3;

        public const int NameMaxLength = 100;

        public const int AddressMinLength = 3;

        public const int AddressMaxLength = 1000;

        public const string MinPrice = "0.01";

        public const string MaxPrice = "79228162514264337593543950335";

        public const int MinQuantity = 1;

        public const int MaxQuantity = int.MaxValue;

        public const int MinPages = 1;

        public const int MaxPages = int.MaxValue;

        public const int MinYearOfIssue = 1900;

        public const int MaxYearOfIssue = 2100;

        public const int AnnotationMinLength = 20;

        public const int AnnotationMaxLength = 1000;

        public const int MinAuthors = 1;

        public const int MinCategories = 1;

        public const int IsbnMaxLength = 13;

        public const int DescriptionMaxLength = 300;

        public const int UrlMaxLength = 1000;

        public const int BooksPerPage = 12;

        public const string DefaultCategoryName = "all";
    }
}
