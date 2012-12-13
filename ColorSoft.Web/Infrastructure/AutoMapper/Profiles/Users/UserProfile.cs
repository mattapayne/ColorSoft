using System;
using AutoMapper;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Infrastructure.AutoMapper.Extensions;
using ColorSoft.Web.Models.Api.Users;
using ColorSoft.Web.Models.Users;
using ColorSoft.Web.Services;

namespace ColorSoft.Web.Infrastructure.AutoMapper.Profiles.Users
{
    public class UserProfile : Profile
    {
        private readonly IPasswordService _passwordService;

        public UserProfile(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        protected override void Configure()
        {
            CreateMap<AddUserViewModel, User>().
                ForMember(d => d.HashedPassword, opt => opt.MapFrom(s => _passwordService.Generate(s.Password))).
                ForMember(d => d.CreatedAt, opt => opt.UseValue(DateTime.UtcNow)).
                ForMember(d => d.DeletedAt, opt => opt.UseValue(null));

            CreateMap<User, UserViewModel>().ForMember(d => d.CreatedAt, opt => opt.MapFrom(s => s.CreatedAt.ToShortDateString()));

            CreateMap<UserViewModel, User>().DoNotSet(d => d.HashedPassword, d => d.CreatedAt, d => d.Id,
                                                      d => d.DeletedAt);
        }
    }
}