namespace ColorSoft.Data.Migrations.Schema
{
    public static class DashBoardNavigationSectionTable
    {
        public const string Name = "DashboardNavigationSections";
        public const string SelectAllSql = "SELECT Id, Name FROM DashboardNavigationSections";
        
        public static class Columns
        {
            public const string Id = "Id";
            public const string Name = "Name";
            public const string IsActive = "IsActive";
            public const string IsAdminOnly = "IsAdminOnly";
        }
    }
}
