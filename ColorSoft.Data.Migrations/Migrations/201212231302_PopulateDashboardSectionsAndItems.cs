using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using ColorSoft.Data.Migrations.Schema;
using FluentMigrator;

namespace ColorSoft.Data.Migrations.Migrations
{
    [Migration(201212231302)]
    public class PopulateDashboardSectionsAndItems : Migration
    {
        private const string FileName = "dashboard-sections-items.xml";
        
        private class Item
        {
            public Guid Id { get; set; }
            public String Name { get; set; }
        }

        public override void Up()
        {
            var doc = ReadFileData();
            var sections = from section in doc.Descendants("section") select section;
            var roles = new List<Item>();

            Execute.WithConnection((cnn, trans) =>
                {
                    using(var cmd = cnn.CreateCommand())
                    {
                        cmd.Transaction = trans;
                        cmd.CommandText = RolesTable.SelectAllSql;

                        using(var reader = cmd.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                roles.Add(new Item {Id = reader.GetGuid(0), Name = reader.GetString(1)});
                            }
                        }
                    }

                    using (var cmd = cnn.CreateCommand())
                    {
                        cmd.Transaction = trans;

                        foreach (var section in sections)
                        {
                            var sectionId = Guid.NewGuid();
                            var sectionName = section.Attribute("name").Value;
                            var sortOrder = section.Attribute("sort-order").Value;
                            var allowedRoles =
                                section.Attribute("allow-roles").Value.Split(new[] {','},
                                                                             StringSplitOptions.RemoveEmptyEntries).
                                    Select(
                                        s => s.Trim()).ToList();

                            var items = from item in section.Descendants("item") select item;


                            cmd.CommandText = String.Format(DashBoardNavigationSectionTable.InsertSql, sectionId,
                                                            sectionName, 1, sortOrder);

                            //create the section
                            cmd.ExecuteNonQuery();

                            //create the roles for the section
                            foreach (var allowedRole in allowedRoles)
                            {
                                var correspondingRole = roles.FirstOrDefault(x => x.Name == allowedRole);

                                if (correspondingRole != null)
                                {
                                    cmd.CommandText =
                                        String.Format(DashboardNavigationSectionsRolesTable.InsertSqlTemplate,
                                                      correspondingRole.Id, sectionId);

                                    cmd.ExecuteNonQuery();
                                }

                            }

                            foreach (var item in items)
                            {
                                var itemId = Guid.NewGuid();
                                var itemName = item.Attribute("name").Value;
                                var itemTemplate = item.Attribute("template").Value;
                                var itemTitle = item.Attribute("title").Value;
                                var itemSortOrder = item.Attribute("sort-order").Value;
                                var itemRoles =
                                    item.Attribute("allow-roles").Value.Split(new[] {','},
                                                                              StringSplitOptions.RemoveEmptyEntries).
                                        Select(s => s.Trim()).ToList();

                                //insert the item
                                cmd.CommandText = String.Format(DashboardNavigationSectionItemTable.InsertTemplateSql,
                                                                itemId, sectionId, itemName, itemTemplate, itemTitle, itemSortOrder);

                                cmd.ExecuteNonQuery();

                                foreach(var role in itemRoles)
                                {
                                    var correspondingRole = roles.FirstOrDefault(x => x.Name == role);

                                    if(correspondingRole != null)
                                    {
                                        cmd.CommandText =
                                            String.Format(DashboardNavigationSectionItemsRolesTable.InsertSqlTemplate,
                                                          correspondingRole.Id, itemId);

                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }
                    }
                });
        }

        private XDocument ReadFileData()
        {
            var path = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.Parent.Parent.FullName;
            var fullPath = Path.Combine(path, FileName);
            return XDocument.Load(fullPath);
        }

        public override void Down()
        {
            Delete.FromTable(DashboardNavigationSectionItemsRolesTable.Name).InSchema(AppSchema.Name);
            Delete.FromTable(DashboardNavigationSectionsRolesTable.Name).InSchema(AppSchema.Name);
            Delete.FromTable(DashboardNavigationSectionItemTable.Name).InSchema(AppSchema.Name);
            Delete.FromTable(DashBoardNavigationSectionTable.Name).InSchema(AppSchema.Name);
        }
    }
}
