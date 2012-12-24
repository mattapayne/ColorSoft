namespace ColorSoft.Data.Migrations.Schema
{
    public static class DashboardNavigationSectionsRolesTable
    {
        public const string Name = "DashboardNavigationSectionsRoles";

        public const string InsertSqlTemplate = "INSERT INTO DashboardNavigationSectionsRoles (RoleId, DashboardNavigationSectionId) VALUES ('{0}', '{1}')";

        public static readonly string RoleFk = string.Format("FK_{0}_{1}", Name,
                                                     RolesTable.Name);

        public static readonly string DashboardNavigationSectionFk = string.Format("FK_{0}_{1}", Name,
                                                                                       DashBoardNavigationSectionTable
                                                                                           .Name);

        public static class Columns
        {
            public static string DashboardNavigationSectionId = "DashboardNavigationSectionId";
            public static string RoleId = "RoleId";
        }
    }
}
