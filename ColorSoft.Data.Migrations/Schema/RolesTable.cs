namespace ColorSoft.Data.Migrations.Schema
{
    public static class RolesTable
    {
        public const string Name = "Roles";
        public const string SelectAllSql = "SELECT Id, [Name] FROM Roles";

        public static class Columns
        {
            public const string Id = "Id";
            public const string Name = "Name";
        }
    }
}
