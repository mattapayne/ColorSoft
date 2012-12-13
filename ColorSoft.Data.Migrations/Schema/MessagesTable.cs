namespace ColorSoft.Data.Migrations.Schema
{
    public static class MessagesTable
    {
        public const string Name = "Messages";

        public static class Columns
        {
            public const string Id = "Id";
            public const string MessageText = "MessageText";
            public const string Subject = "Subject";
            public const string From = "From";
            public const string CreatedAt = "CreatedAt";
        }
    }
}
