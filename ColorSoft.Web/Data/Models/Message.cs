using System;

namespace ColorSoft.Web.Data.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string MessageText { get; set; }
        public string From { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}