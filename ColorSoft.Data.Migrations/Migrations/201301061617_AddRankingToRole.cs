using ColorSoft.Data.Migrations.Schema;
using FluentMigrator;

namespace ColorSoft.Data.Migrations.Migrations
{
    [Migration(201301061617)]
    public class AddRankingToRole : Migration
    {
        public override void Up()
        {
            Create.Column(RolesTable.Columns.Rank).OnTable(RolesTable.Name).InSchema(AppSchema.Name).AsInt32().
                NotNullable().WithDefaultValue(0);

            Execute.Sql(@"
                UPDATE Roles SET Rank = 1 WHERE [Name] = 'Organization Administrator';
                UPDATE Roles SET Rank = 2 WHERE [Name] = 'Organization User';
            ");
        }

        public override void Down()
        {
            Delete.Column(RolesTable.Columns.Rank).FromTable(RolesTable.Name).InSchema(AppSchema.Name);
        }
    }
}
