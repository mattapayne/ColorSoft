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
            return users.Select(u => MappingEngine.Map<User, UserViewModel>(u));
        }

        public void Post(AddUserViewModel model)
        {
            var user = MappingEngine.Map<AddUserViewModel, User>(model);
            _userService.Create(user);
        }

        public void Put(UserViewModel model)
        {
            if(model == null || !model.Id.HasValue)
            {
                throw  new ArgumentNullException("model");
            }

            var user = _userService.GetById(model.Id.Value);
            MappingEngine.Map(model, user);
            _userService.Update(user);
        }

        [HttpPost]
        public void Delete(UserViewModel model)
        {
            if (model == null || !model.Id.HasValue)
            {
                throw new ArgumentNullException("model");
            }

            _userService.Delete(model.Id.Value);
        }

        [HttpPost]
        public void DeleteAll(UserViewModel[] models)
        {
            if (models != null)
            {
                _userService.Delete(models.Where(m => m.Id.HasValue).Select(m => m.Id.Value).ToArray());
            }
        }
    }
}