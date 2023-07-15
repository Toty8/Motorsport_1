namespace Motorsport1.Common
{
    public static class UIMessages
    {
        public static class ErrorMessages
        {
            public const string InvalidCategory = "Selected category is invalid!";
            public const string InvalidModelState = "Please enter valid data!";
            public const string UnexpectedError = "Unexpected error occured! Please try again or contact administrator!";

            public const string UnexistingArticle = "Article with the provided id does not exist!";

            public const string UnexistingDriver = "Driver with the provided id does not exist!";
            public const string DriverAreEnough = "There are already enough drivers!";
        }

        public static class WarningMessages { }

        public static class InformationMessages 
        {
            public const string InformationDeletedArticle = "Your article was successfully deleted!";
            public const string InformationDeletedDriver = "You succesfully unactivated a driver!";
        }

        public static class SuccessMessages
        { 
            public const string SuccessfullyAddedArticle = "Your article is successfully published!"; 
            public const string SuccessfullyEditedArticle = "Your article is successfully edited!";
        }
    }
}
