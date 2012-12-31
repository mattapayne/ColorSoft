using System;
using System.Collections.Generic;
using System.Linq;

namespace ColorSoft.Web.Data.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string HashedPassword { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public Guid? OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public User()
        {
            Roles = Enumerable.Empty<string>();
            Id = Guid.NewGuid();
        }
    }
}