using System;

namespace ColorSoft.Web.Data.Models
{
    public class Organization
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Organization()
        {
            Id = Guid.NewGuid();
        }
    }
}