using System.Linq.Expressions;

namespace Motorsport1.Common
{
    public static class EntityValidationConstants
    {
        public static class Category
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 50;
        }

        public static class Article
        {
            public const int TitleMinLength = 10;
            public const int TitleMaxLength = 150;

            public const int InformationMinLength = 150;
            public const int InformationMaxLength = 100000;

            public const int ImageUrlMaxLength = 2048;

            public const string LikesDefaulValue = "0";

            public const string ReadCountDefaulValue = "0";
        }

        public static class Comment
        {
            public const int ContentMinLength = 1;
            public const int ContentMaxLength = 200;
        }
    }
}
