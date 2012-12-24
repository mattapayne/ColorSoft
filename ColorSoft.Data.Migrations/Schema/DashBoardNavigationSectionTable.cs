namespace ColorSoft.Data.Migrations.Schema
{
    public static class DashBoardNavigationSectionTable
    {
        public const string Name = "DashboardNavigationSections";
        public const string SelectAllSql = "SELECT Id, [Name] FROM DashboardNavigationSections";

        public const string InsertSql =
            "INSERT INTO DashboardNavigationSections (Id, [Name], IsActive, SortOrder) VALUES ('{0}', '{1}', {2}, {3})";
        
        public static class Columns
        {
            public const string Id = "Id";
            public const string Name = "Name";
            public const string IsActive = "IsActive";
            public const string SortOrder = "SortOrder";
        }
    }
}
