using System;
using ColorSoft.Data.Migrations.Schema;
using FluentMigrator;

namespace ColorSoft.Data.Migrations.Migrations
{
    [Migration(201212011514)]
    public class AddMessagesTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table(MessagesTable.Name).InSchema(AppSchema.Name).
                WithColumn(MessagesTable.Columns.Id).AsGuid().PrimaryKey().WithDefaultValue(SystemMethods.NewGuid).
                WithColumn(MessagesTable.Columns.Subject).AsString(100).NotNullable().
                WithColumn(MessagesTable.Columns.MessageText).AsString(Int32.MaxValue).
                WithColumn(MessagesTable.Columns.From).AsString(100).NotNullable().WithColumn(
                    MessagesTable.Columns.CreatedAt).AsDateTime().NotNullable().WithDefaultValue(
                        SystemMethods.CurrentUTCDateTime);
        }
    }
}
