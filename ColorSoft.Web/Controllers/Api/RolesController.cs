using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Models.Api.Roles;
using ColorSoft.Web.Queries.Roles;

namespace ColorSoft.Web.Controllers.Api
{
    [Authorize(Roles = Role.AnyAdministrator)]
    public class RolesController : AuthenticatedApiController
    {
        private readonly IGetRolesLimitedByCurrentUserQuery _getRolesLimitedByCurrentUserQuery;

        public RolesController(IMappingEngine mappingEngine, IGetRolesLimitedByCurrentUserQuery getRolesLimitedByCurrentUserQuery) 
            : base(mappingEngine)
        {
            _getRolesLimitedByCurrentUserQuery = getRolesLimitedByCurrentUserQuery;
        }

        [HttpGet]
        public IEnumerable<RoleViewModel> Index()
        {
            var roles = _getRolesLimitedByCurrentUserQuery.Execute();
            return MappingEngine.Map<IEnumerable<Role>, IEnumerable<RoleViewModel>>(roles);
        }
    }
}
