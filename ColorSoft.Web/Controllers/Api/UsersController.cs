using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Models.Api.Users;
using ColorSoft.Web.Models.Users;
using ColorSoft.Web.Services.Users;

namespace ColorSoft.Web.Controllers.Api
{
    [Authorize(Roles = Role.AnyAdministrator)]
    public class UsersController : AuthenticatedApiController
    {
        private readonly IUserService _userService;

        public UsersController(
            IMappingEngine mappingEngine, IUserService userService)
            : base(mappingEngine)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<UserViewModel> Index()
        {
            var users = _userService.GetAllNonDeletedUsers();
            return MappingEngine.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users);
        }

        [HttpPost]
        public void Create(AddUserViewModel model)
        {
            var user = MappingEngine.Map<AddUserViewModel, User>(model);
            _userService.Create(user);
        }

        [HttpPut]
        public void Update(UserViewModel model)
        {
            if(model == null || !model.Id.HasValue)
            {
                throw  new ArgumentNullException("model");
            }

            var user = _userService.GetById(model.Id.Value);
            MappingEngine.Map(model, user);
            _userService.Update(user);
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            _userService.Delete(id);
        }

        [HttpPost]
        public void DeleteAll(Guid[] ids)
        {
            if (ids != null)
            {
                _userService.Delete(ids);
            }
        }
    }
}