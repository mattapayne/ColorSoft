using AutoMapper;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Models.Api.Organizations;

namespace ColorSoft.Web.Infrastructure.AutoMapper.Profiles.Organizations
{
    public class OrganizationProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Organization, OrganizationViewModel>();
            CreateMap<OrganizationViewModel, Organization>();
            CreateMap<AddOrganizationViewModel, Organization>();
        }
    }
}