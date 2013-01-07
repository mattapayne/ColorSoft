using AutoMapper;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Models.Api.Roles;

namespace ColorSoft.Web.Infrastructure.AutoMapper.Profiles.Roles
{
    public class RoleProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Role, RoleViewModel>();
        }
    }
}