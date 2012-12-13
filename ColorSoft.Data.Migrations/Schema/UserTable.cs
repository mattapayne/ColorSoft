namespace ColorSoft.Data.Migrations.Schema
{
    public static class UserTable
    {
        public const string Name = "Users";
        public const string SelectDefaultUserSql = "SELECT Id FROM Users WHERE UserName = 'mattapayne'";
        public const string OrganizationForeignKeyName = "FK_Users_Organization";

        public static class Columns
        {
            public const string Id = "Id";
            public const string FirstName = "FirstName";
            public const string LastName = "LastName";
            public const string UserName = "UserName";
            public const string EmailAddress = "EmailAddress";
            public const string HashedPassword = "HashedPassword";
            public const string CreatedAt = "CreatedAt";
            public const string UpdatedAt = "UpdatedAt";
            public const string DeletedAt = "DeletedAt";
            public const string OrganizationId = "OrganizationId";
        }
    }
}
