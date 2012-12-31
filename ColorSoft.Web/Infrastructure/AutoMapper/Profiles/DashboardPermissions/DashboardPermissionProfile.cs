using AutoMapper;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Models.Api.DashboardPermissions;
using ColorSoft.Web.Services;

namespace ColorSoft.Web.Infrastructure.AutoMapper.Profiles.DashboardPermissions
{
    public class DashboardPermissionProfile : Profile
    {
        private readonly ITemplateUrlGenerationService _urlGenerationService;

        public DashboardPermissionProfile(ITemplateUrlGenerationService urlGenerationService)
        {
            _urlGenerationService = urlGenerationService;
        }

        protected override void Configure()
        {
            CreateMap<DashboardNavigationSectionItem, DashboardPermissionViewModel>().
                ForMember(d => d.TemplateUrl, opt => opt.MapFrom(s => _urlGenerationService.Generate(s.Template)));
        }
    }
}