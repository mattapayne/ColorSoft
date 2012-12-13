using ColorSoft.Data.Migrations.Schema;
using FluentMigrator;

namespace ColorSoft.Data.Migrations.Migrations
{
    [Migration(201211241802)]
    public class AddDashboardNavigationTablesAndData : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table(DashBoardNavigationSectionTable.Name).InSchema(AppSchema.Name).
                WithColumn(DashBoardNavigationSectionTable.Columns.Id).AsGuid().PrimaryKey().NotNullable().
                WithDefaultValue(SystemMethods.NewSequentialId).
                WithColumn(DashBoardNavigationSectionTable.Columns.Name).AsString(255).NotNullable().
                WithColumn(DashBoardNavigationSectionTable.Columns.IsActive).AsBoolean().NotNullable().WithDefaultValue(
                    true).WithColumn(DashBoardNavigationSectionTable.Columns.IsAdminOnly).AsBoolean().NotNullable().
                WithDefaultValue(false);

            Insert.IntoTable(DashBoardNavigationSectionTable.Name).InSchema(AppSchema.Name).Row(new
                {
                    Name = "Color Matches"
                });

            Insert.IntoTable(DashBoardNavigationSectionTable.Name).InSchema(AppSchema.Name).Row(new
                {
                    Name = "Users"
                });

            Insert.IntoTable(DashBoardNavigationSectionTable.Name).InSchema(AppSchema.Name).Row(new
                {
                    Name = "Products"
                });

            Insert.IntoTable(DashBoardNavigationSectionTable.Name).InSchema(AppSchema.Name).Row(new
                {
                    Name = "Administration",
                    IsAdminOnly = true
                });
        }
    }
}
