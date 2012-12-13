using AutoMapper;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Infrastructure.AutoMapper.Resolvers.DashboardNavigation;
using ColorSoft.Web.Models.DashboardNavigation;

namespace ColorSoft.Web.Infrastructure.AutoMapper.Profiles.DashboardNavigation
{
    public class DashboardNavigationSectionProfile : Profile
    {
        private readonly IFactory<DashboardNavigationSectionItemViewModelResolver> _resolverFactory;

        public DashboardNavigationSectionProfile(IFactory<DashboardNavigationSectionItemViewModelResolver> resolverFactory)
        {
            _resolverFactory = resolverFactory;
        }

        protected override void Configure()
        {
            CreateMap<DashboardNavigationSection, DashboardNavigationSectionViewModel>().
                ForMember(dest => dest.Items,
                          opt =>
                          opt.ResolveUsing(
                              _resolverFactory.
                                  Construct()));
        }
    }
}