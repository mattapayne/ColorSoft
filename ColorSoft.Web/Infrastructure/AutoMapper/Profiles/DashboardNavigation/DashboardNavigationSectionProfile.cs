using System.Linq;
using AutoMapper;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Infrastructure.AutoMapper.Resolvers.DashboardNavigation;
using ColorSoft.Web.Models.DashboardNavigation;

namespace ColorSoft.Web.Infrastructure.AutoMapper.Profiles.DashboardNavigation
{
    public class DashboardNavigationSectionProfile : Profile
    {
        private readonly IFactory<DashboardNavigationSectionItemViewModelResolver> _itemResolverFactory;

        public DashboardNavigationSectionProfile(
            IFactory<DashboardNavigationSectionItemViewModelResolver> itemResolverFactory)
        {
            _itemResolverFactory = itemResolverFactory;
        }

        protected override void Configure()
        {
            CreateMap<DashboardNavigationSection, DashboardNavigationSectionViewModel>().
                ForMember(d => d.Roles, opts => opts.MapFrom(s => s.Roles.Select(r => r.Name))).
                ForMember(dest => dest.Items,
                          opt =>
                          opt.ResolveUsing(
                              _itemResolverFactory.
                                  Construct()));
        }
    }
}