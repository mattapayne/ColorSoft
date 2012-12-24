namespace ColorSoft.Data.Migrations.Schema
{
    public static class DashboardNavigationSectionItemTable
    {
        public const string Name = "DashboardNavigationSectionItems";
        public const string ForeignKeyName = "FK_DashboardNavigationSection_DashboardNavigationSectionItem";

        public const string InsertTemplateSql =
            "INSERT INTO DashboardNavigationSectionItems (Id, DashboardNavigationSectionId, [Name], Link, Title, SortOrder) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', {5})";

        public static class Columns
        {
            public const string Id = "Id";
            public const string DashboardNavigationSectionId = "DashboardNavigationSectionId";
            public const string Name = "Name";
            public const string Link = "Link";
            public const string Title = "Title";
            public const string IsActive = "IsActive";
            public const string SortOrder = "SortOrder";
        }
    }
}
