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
            public const string UnexistingDriverByName = "Driver with the provided name does not exist!";
            public const string ExistingDriverByName = "Driver with the provided name already exist!";
            public const string DriverAreEnough = "There are already enough drivers!";
            public const string DriverNumberTaken = "This racing number is already taken!";
            public const string DriverIsnotCurrentChampion = "Driver must be the current world chamion to race with number 1!";

            public const string InvalidTeam = "Selected team is invalid!";
            public const string FullTeam = "Selected team is already have enough drivers!";
            public const string UnexistingTeam = "Team with the provided id does not exist!";
            public const string InactiveTeam = "Team with the provided id is not active!";

        }

        public static class WarningMessages { }

        public static class InformationMessages 
        {
            public const string InformationDeletedArticle = "Your article was successfully deleted!";

            public const string InformationUnactivatedDriver = "You succesfully unactivated a driver!";

            public const string InformationUnactivatedTeam = "You succesfully unactivated a team!";
        }

        public static class SuccessMessages
        { 
            public const string SuccessfullyAddedArticle = "Your article is successfully published!"; 
            public const string SuccessfullyEditedArticle = "Your article is successfully edited!";

            public const string SuccessfullyAddedDriver = "Your driver is successfully added!";
            public const string SuccessfullyEditedDriver = "Your driver is successfully edited!";

        }
    }
}
