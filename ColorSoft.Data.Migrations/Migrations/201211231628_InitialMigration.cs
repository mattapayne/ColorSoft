using ColorSoft.Data.Migrations.Schema;
using FluentMigrator;

namespace ColorSoft.Data.Migrations.Migrations
{
    [Migration(201211231628)]
    public class InitialMigration : Migration
    {
        public override void Up()
        {
            Create.Table(OrganizationTable.Name).InSchema(AppSchema.Name).
                WithColumn(OrganizationTable.Columns.Id).AsGuid().NotNullable().PrimaryKey().WithDefaultValue(
                    SystemMethods.NewGuid).WithColumn(OrganizationTable.Columns.Name).AsString(255).NotNullable().
                Indexed();

            Create.Table(UserTable.Name).InSchema(AppSchema.Name).
                WithColumn(UserTable.Columns.Id).AsGuid().PrimaryKey().NotNullable().WithDefault(SystemMethods.NewGuid).
                WithColumn(UserTable.Columns.FirstName).AsString(100).NotNullable().
                WithColumn(UserTable.Columns.LastName).AsString(100).NotNullable().
                WithColumn(UserTable.Columns.UserName).AsString(100).NotNullable().Indexed().
                WithColumn(UserTable.Columns.EmailAddress).AsString(100).NotNullable().
                WithColumn(UserTable.Columns.HashedPassword).AsString(255).NotNullable().
                WithColumn(UserTable.Columns.CreatedAt).AsDateTime().NotNullable().WithDefault(
                    SystemMethods.CurrentUTCDateTime).
                WithColumn(UserTable.Columns.UpdatedAt).AsDateTime().Nullable().
                WithColumn(UserTable.Columns.DeletedAt).AsDateTime().Nullable().Indexed().
                WithColumn(UserTable.Columns.OrganizationId).AsGuid().Nullable();

            Create.Table(RolesTable.Name).InSchema(AppSchema.Name).
                WithColumn(RolesTable.Columns.Id).AsGuid().NotNullable().PrimaryKey().WithDefaultValue(
                    SystemMethods.NewGuid).WithColumn(RolesTable.Columns.Name).AsString(255).NotNullable();

            Create.Table(UsersRolesTable.Name).InSchema(AppSchema.Name).
                WithColumn(UsersRolesTable.Columns.UserId).AsGuid().NotNullable().
                WithColumn(UsersRolesTable.Columns.RoleId).AsGuid().NotNullable();

            Create.ForeignKey(UserTable.OrganizationForeignKeyName).FromTable(UserTable.Name).ForeignColumn(
                UserTable.Columns.OrganizationId).ToTable(OrganizationTable.Name).InSchema(AppSchema.Name).PrimaryColumn
                (OrganizationTable.Columns.Id);

            Create.ForeignKey(UsersRolesTable.UserForeignKeyName).FromTable(UsersRolesTable.Name).ForeignColumn(
                UsersRolesTable.Columns.UserId).ToTable(UserTable.Name).InSchema(AppSchema.Name).PrimaryColumn(
                    UserTable.Columns.Id);

            Create.ForeignKey(UsersRolesTable.RolesForeignKeyName).FromTable(UsersRolesTable.Name).ForeignColumn(
                UsersRolesTable.Columns.RoleId).ToTable(RolesTable.Name).InSchema(AppSchema.Name).PrimaryColumn(
                    RolesTable.Columns.Id);

            Create.PrimaryKey().OnTable(UsersRolesTable.Name).WithSchema(AppSchema.Name).Columns(new[]
                {UsersRolesTable.Columns.RoleId, UsersRolesTable.Columns.UserId});

            Insert.IntoTable(UserTable.Name).InSchema(AppSchema.Name).Row(new
                {
                    FirstName = "Matt",
                    LastName = "Payne",
                    UserName = "mattapayne",
                    EmailAddress = "paynmatt@gmail.com",
                    HashedPassword = "D0763EDAA9D9BD2A9516280E9044D885"
                });

            Insert.IntoTable(RolesTable.Name).InSchema(AppSchema.Name).Row(new
                {
                    Name = "ColorSoft Administrator"
                });

            Insert.IntoTable(RolesTable.Name).InSchema(AppSchema.Name).Row(new
                {
                    Name = "Organization Administrator"
                });

            Insert.IntoTable(RolesTable.Name).InSchema(AppSchema.Name).Row(new
                {
                    Name = "Organization User"
                });
        }

        public override void Down()
        {
            Delete.Table(UsersRolesTable.Name).InSchema(AppSchema.Name);
            Delete.Table(RolesTable.Name).InSchema(AppSchema.Name);
            Delete.Table(UserTable.Name).InSchema(AppSchema.Name);
            Delete.Table(OrganizationTable.Name).InSchema(AppSchema.Name);
        }
    }
}
