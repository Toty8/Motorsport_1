using System.Linq.Expressions;

namespace Motorsport1.Common
{
    public static class EntityValidationConstants
    {
        public static class User
        {
            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 20;

            public const int LastNameMinLength = 1;
            public const int LastNameMaxLength = 20;

            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 100;
        }

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
        }

        public static class Comment
        {
            public const int ContentMinLength = 1;
            public const int ContentMaxLength = 200;
        }

        public static class Driver
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 100;

            public const string PriceMinValue = "0";
            public const string PriceMaxValue = "100";

            public const string NumberMaxValue = "99";
            public const string NumberMinValue = "1";

            public const int ImageUrlMaxLength = 2048;
        }

        public static class Team
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 100;

            public const string PriceMinValue = "0";
            public const string PriceMaxValue = "100";

            public const int ImageUrlMaxLength = 2048;
        }

        public static class Standing
        {
            public const string PositionMinValue = "1";
            public const string PositionMaxValue = "20";
        }
    }
}
