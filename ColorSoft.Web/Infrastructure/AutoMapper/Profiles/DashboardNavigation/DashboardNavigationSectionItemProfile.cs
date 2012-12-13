using AutoMapper;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Models.DashboardNavigation;

namespace ColorSoft.Web.Infrastructure.AutoMapper.Profiles.DashboardNavigation
{
    public class DashboardNavigationSectionItemProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<DashboardNavigationSectionItem, DashboardNavigationSectionItemViewModel>();
        }
    }
}