using System;
using ColorSoft.Data.Migrations.Schema;
using FluentMigrator;

namespace ColorSoft.Data.Migrations.Migrations
{
    [Migration(201211231700)]
    public class AddDefaultUserToRole : Migration
    {
        public override void Up()
        {
            Execute.WithConnection((conn, trans) =>
                {
                    using(var cmd = conn.CreateCommand())
                    {
                        Guid? userId = null;
                        Guid? roleId = null;

                        cmd.Transaction = trans;
                        cmd.CommandText = UserTable.SelectDefaultUserSql;

                        using(var reader = cmd.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                userId = reader.GetGuid(0);
                            }
                        }

                        if(userId.HasValue)
                        {
                            cmd.CommandText = UsersRolesTable.SelectColorSoftAdminRoleSql;

                            using(var reader = cmd.ExecuteReader())
                            {
                                if(reader.Read())
                                {
                                    roleId = reader.GetGuid(0);
                                }
                            }
                        }

                        if(userId.HasValue && roleId.HasValue)
                        {
                            cmd.CommandText = String.Format(UsersRolesTable.InsertSqlTemplate, userId, roleId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                });
        }

        public override void Down()
        {
            Delete.FromTable(UsersRolesTable.Name).InSchema(AppSchema.Name);
        }
    }
}
