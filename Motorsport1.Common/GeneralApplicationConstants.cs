namespace Motorsport1.Common
{
    public static class GeneralApplicationConstants
    {
        public const int ReleaseYear = 2023;

        public const int DefaulPage = 1;
        public const int EntitiesPerPage = 3;

        public const int MaxDrivers = 20;

        public const int MaxTeams = 10;
        public const int MaxDriversPerTeam = 2;

        public const decimal DraftBudget = 100M;

        public const string AdminRoleName = "Administrator";
        public const string AdminAreaName = "Admin";
        public const string DevelopmentAdminEmail = "Admin@admin.com";

        public const string PublisherRoleName = "Publisher";
        public const string DevelopmentPublisherEmail = "Publisher@publisher.com";

        public const string OnlineUserCookieName = "IsOnline";
        public const int LastActivityBeforeOfflineMinutes = 10;
    }
}