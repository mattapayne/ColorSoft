using System;
using System.Collections.Generic;

namespace ColorSoft.Web.Data.Models
{
    public class DashboardNavigationSectionItem
    {
        public Guid Id { get; set; }
        public Guid DashboardNavigationSectionId { get; set; }
        public string Name { get; set; }
        public string Template { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }
        public IEnumerable<Role> Roles { get; set; } 

        public DashboardNavigationSectionItem()
        {
            Roles = new List<Role>();
        }
    }
}