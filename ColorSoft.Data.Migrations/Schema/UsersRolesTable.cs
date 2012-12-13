namespace ColorSoft.Data.Migrations.Schema
{
    public static class UsersRolesTable
    {
        public const string Name = "UsersRoles";
        public const string UserForeignKeyName = "FK_UsersRoles_User";
        public const string RolesForeignKeyName = "FK_UsersRoles_Role";

        public const string SelectColorSoftAdminRoleSql =
            "SELECT Id FROM Roles WHERE [Name] = 'ColorSoft Administrator'";

        public const string InsertSqlTemplate = "INSERT INTO UsersRoles (UserId, RoleId) VALUES ('{0}', '{1}')";

        public static class Columns
        {
            public const string UserId = "UserId";
            public const string RoleId = "RoleId";
        }
    }
}
