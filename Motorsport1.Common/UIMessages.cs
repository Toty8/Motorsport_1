﻿namespace Motorsport1.Common
{
    public static class UIMessages
    {
        public static class ErrorMessages
        {
            public const string InvalidCategory = "Selected category is invalid!";
            public const string InvalidModelState = "Please enter valid data!";
            public const string UnexpectedError = "Unexpected error occured! Please try again or contact an administrator.";

            public const string UnexistingArticle = "Article with the provided id does not exist!";
        }

        public static class WarningMessages { }

        public static class InformationMessages { }

        public static class SuccessMessages
        { 
            public const string SuccessfullyAddedArticle = "Your article is successfully published"; 
        }
    }
}
