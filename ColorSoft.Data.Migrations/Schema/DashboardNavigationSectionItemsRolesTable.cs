namespace ColorSoft.Data.Migrations.Schema
{
    public static class DashboardNavigationSectionItemsRolesTable
    {
        public const string Name = "DashboardNavigationSectionItemsRoles";

        public static readonly string RoleFk = string.Format("FK_{0}_{1}", Name,
                                                             RolesTable.Name);

        public const string InsertSqlTemplate = "INSERT INTO DashboardNavigationSectionItemsRoles (RoleId, DashboardNavigationSectionItemId) VALUES ('{0}', '{1}')";


        public static readonly string DashboardNavigationSectionItemFk = string.Format("FK_{0}_{1}", Name,
                                                                                       DashboardNavigationSectionItemTable
                                                                                           .Name);

        public static class Columns
        {
            public static string DashboardNavigationSectionItemId = "DashboardNavigationSectionItemId";
            public static string RoleId = "RoleId";
        }
    }
}
