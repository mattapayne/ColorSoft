using System;

namespace ColorSoft.Web.Models.Api.Roles
{
    public class RoleViewModel
    {
        public Guid Id { get; set; }
        public int Rank { get; set; }
        public string Name { get; set; }
    }
}