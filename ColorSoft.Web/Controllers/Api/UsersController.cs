using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Filters;
using ColorSoft.Web.Infrastructure;
using ColorSoft.Web.Models.Api.Users;
using ColorSoft.Web.Services.Users;
using ColorSoft.Web.Validation;

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
        [ModelRequired]
        public HttpResponseMessage Create(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = MappingEngine.Map<AddUserViewModel, User>(model);

                try
                {
                    _userService.Create(user);
                    user = _userService.GetById(user.Id);
                    return CreatedResponse(MappingEngine.Map<User, UserViewModel>(user));
                }
                catch (ApplicationValidationException ae)
                {
                    AddModelStateErrors(ae);
                }
                catch (Exception ex)
                {
                    return ExceptionErrorResponse(ex);
                }
            }

            return ModelStateErrorResponse();
        }

        [HttpPut]
        [ModelRequired]
        public HttpResponseMessage Update(UserViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var user = _userService.GetById(model.Id);
                    MappingEngine.Map(model, user);
                    _userService.Update(user);
                    return UpdatedResponse();
                }
                catch (ApplicationValidationException ae)
                {
                    AddModelStateErrors(ae);
                }
                catch (Exception ex)
                {
                    return ExceptionErrorResponse(ex);
                }
            }

            return ModelStateErrorResponse();
        }

        [HttpPost]
        [ModelRequired(ModelParameterName = "ids")]
        public HttpResponseMessage Delete(Guid[] ids)
        {
            try
            {
                _userService.Delete(ids);
                return DeletedResponse();
            }
            catch (Exception ex)
            {
                return ExceptionErrorResponse(ex);
            }
        }
    }
}