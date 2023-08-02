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
            public const string AlreadyLikedArticle = "This article has already been liked by you!";
            public const string NotYourArticle = "This article you are trying to reach is not yours!";

            public const string InvalidDriver = "Selected driver is invalid!";
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
            public const string TeamsAreEnough = "There are already enough teams!";
            public const string ExistingTeamByName = "Team with the provided name already exist!";
            public const string TeamIsTooExpencive = "Team price is too high!";

            public const string UnexistingComment = "Comment with the provided id does not exist!";
            public const string NotYourComment = "This comment you are trying to reach is not yours!";

            public const string AlreadyDraftedUser = "You have already made a draft!";
        }

        public static class WarningMessages { }

        public static class InformationMessages 
        {
            public const string InformationDeletedArticle = "Your article was successfully deleted!";

            public const string InformationUnactivatedDriver = "You succesfully unactivated a driver!";

            public const string InformationUnactivatedTeam = "You succesfully unactivated a team!";

            public const string InformationDeletedComment = "Your comment was successfully deleted!";

            public const string SelectedDriverFirst = "You must select a driver before you select a team!";
        }

        public static class SuccessMessages
        { 
            public const string SuccessfullyAddedArticle = "Your article is successfully published!"; 
            public const string SuccessfullyEditedArticle = "Your article is successfully edited!";

            public const string SuccessfullyAddedDriver = "Driver is successfully added!";
            public const string SuccessfullyEditedDriver = "Driver is successfully edited!";

            public const string SuccessfullyAddedTeam = "Team is successfully added!";
            public const string SuccessfullyEditedTeam = "Team is successfully edited!";

            public const string SuccessfullyAddedComment = "Your comment is successfully added!";
            public const string SuccessfullyEditedComment = "Your comment is successfully edited!";

            public const string SuccessfullyAppliedStatistics = "Your statistics are successfully applied!";
            
            public const string SuccessfullyEditedDriverDraftPrice = "Driver draft price is successfully edited!"; 
            public const string SuccessfullyEditedTeamDraftPrice = "Team draft price is successfully edited!"; 
            public const string SuccessfullySelectedDriver = "You successfully chose your driver!"; 
            public const string SuccessfullySelectedTeam = "You successfully chose your team!"; 
        }
    }
}
