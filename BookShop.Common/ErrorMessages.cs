namespace BookShop.Common
{
    public static class ErrorMessages
    {
        public const string NotRequire = "Полето не може да е празно!";

        public const string InvalidBookName = "Името трябва да бъде между 3 и 100 символа!";

        public const string InvalidPrice = "Цената трябва да бъде положително число!";

        public const string InvalidQuantity = "Количеството трябва да бъде положително число!";

        public const string InvalidPages = "Страниците трябва да бъдат положително число!";

        public const string InvalidIsbn = "ISBN трябва да бъде точко 13 цифри дълго!";

        public const string InvalidYear = "Годината на издаване трябва да бъде между 1900 и 2100!";

        public const string InvalidAnnotation = "Анотацията трябва да е между 20 и 1000 символа";

        public const string InvalidPublisherName = "Името на издателството трябва да бъде между 3 и 100 символа!";

        public const string InvalidAuthorsCount = "Трабва да има поне един автор!";

        public const string InvalidAuthorName = "Името на всички автори трябва да бъде между 3 и 100 символа!";

        public const string InvalidCategoriesCount = "Трабва да има поне edna категория!";

        public const string InvalidCategoryName = "Името на всички категории трябва да бъде между 3 и 100 символа!";

        public const string InvalidPhoto = "Всички файлове трябва да съдат снимки!";
    }
}
