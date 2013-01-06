using System;

namespace ColorSoft.Web.Models.Api.Messages
{
    public class MessageViewModel
    {
        public Guid Id { get; set; }
        public string CreatedAt { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}