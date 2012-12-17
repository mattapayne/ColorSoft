using System;
using System.Collections.Generic;
using ColorSoft.Data.Migrations.Schema;
using FluentMigrator;

namespace ColorSoft.Data.Migrations.Migrations
{
    [Migration(201211241820)]
    public class AddDashboardNavigationSectionItemsData : Migration
    {
        private class Section
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }

        public override void Up()
        {
            var inserts = new List<string>();

            Execute.WithConnection((conn, trans) =>
                {
                    var sections = new List<Section>();

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = trans;
                        cmd.CommandText = DashBoardNavigationSectionTable.SelectAllSql;

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var id = reader.GetGuid(0);
                                var name = reader.GetString(1);
                                sections.Add(new Section {Id = id, Name = name});
                            }
                        }
                    }

                    foreach (var section in sections)
                    {
                        switch (section.Name)
                        {
                            case "Color Matches":
                                inserts.Add(String.Format(DashboardNavigationSectionItemTable.InsertTemplateSql,
                                                          section.Id,
                                                          "Search Matches", "#/ColorMatches/Search", 0));
                                break;
                            case "Users":
                                inserts.Add(String.Format(DashboardNavigationSectionItemTable.InsertTemplateSql,
                                                          section.Id,
                                                          "List", "#/Users", 0));
                                break;
                            case "Products":
                                inserts.Add(String.Format(DashboardNavigationSectionItemTable.InsertTemplateSql,
                                                          section.Id,
                                                          "List", "#/Products", 0));
                                break;
                            case "Administration":
                                inserts.Add(String.Format(DashboardNavigationSectionItemTable.InsertTemplateSql,
                                                          section.Id,
                                                          "Organizations", "#/Organizations", 1));
                                inserts.Add(String.Format(DashboardNavigationSectionItemTable.InsertTemplateSql,
                                                          section.Id,
                                                          "Messages", "#/Messages", 1));
                                break;
                        }
                    }

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.Transaction = trans;

                        foreach (var insert in inserts)
                        {
                            cmd.CommandText = insert;
                            cmd.ExecuteNonQuery();
                        }
                    }
                });
        }

        public override void Down()
        {
            Delete.FromTable(DashboardNavigationSectionItemTable.Name).InSchema(AppSchema.Name).AllRows();
        }
    }
}
