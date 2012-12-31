using System.Linq;
using AutoMapper;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Models.DashboardNavigation;

namespace ColorSoft.Web.Infrastructure.AutoMapper.Profiles.DashboardNavigation
{
    public class DashboardNavigationSectionItemProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<DashboardNavigationSectionItem, DashboardNavigationSectionItemViewModel>().
                ForMember(dest => dest.FullPath, opts => opts.Ignore()).
                ForMember(dest => dest.DashboardNavigationSectionName, opts => opts.Ignore()).
                ForMember(dest => dest.Roles, opt => opt.MapFrom(s => s.Roles.Select(r => r.Name)));
        }
    }
}