using System;
using FluentMigrator;
using ColorSoft.Data.Migrations.Schema;

namespace ColorSoft.Data.Migrations.Migrations
{
    [Migration(201211241813)]
    public class AddDashboardNavigationSectionItems : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table(DashboardNavigationSectionItemTable.Name).InSchema(AppSchema.Name).
                WithColumn(DashboardNavigationSectionItemTable.Columns.Id).AsGuid().PrimaryKey().NotNullable().
                WithDefaultValue(SystemMethods.NewSequentialId).
                WithColumn(DashboardNavigationSectionItemTable.Columns.DashboardNavigationSectionId).AsGuid().
                NotNullable().
                WithColumn(DashboardNavigationSectionItemTable.Columns.Name).AsString(255).NotNullable().
                WithColumn(DashboardNavigationSectionItemTable.Columns.Link).AsString(Int32.MaxValue).NotNullable().
                WithColumn(DashboardNavigationSectionItemTable.Columns.IsActive).AsBoolean().NotNullable().
                WithDefaultValue(true).
                WithColumn(DashboardNavigationSectionItemTable.Columns.IsAdminOnly).AsBoolean().NotNullable().
                WithDefaultValue(false);

            Create.ForeignKey(DashboardNavigationSectionItemTable.ForeignKeyName).FromTable(
                DashboardNavigationSectionItemTable.Name).InSchema(AppSchema.Name).ForeignColumn(
                    DashboardNavigationSectionItemTable.Columns.DashboardNavigationSectionId).ToTable(
                        DashBoardNavigationSectionTable.Name).InSchema(AppSchema.Name).PrimaryColumn(
                            DashBoardNavigationSectionTable.Columns.Id);
        }
    }
}
