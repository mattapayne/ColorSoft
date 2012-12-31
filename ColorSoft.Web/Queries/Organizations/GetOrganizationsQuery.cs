using System.Collections.Generic;
using System.Linq;
using ColorSoft.Web.Data;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Infrastructure.Authentication;

namespace ColorSoft.Web.Queries.Organizations
{
    public class GetOrganizationsQuery : IGetOrganizationsQuery
    {
        private readonly IDatabaseProvider _connection;
        private readonly IApplicationUser _user;

        public GetOrganizationsQuery(IDatabaseProvider connection, IApplicationUser user)
        {
            _connection = connection;
            _user = user;
        }

        public IEnumerable<Organization> Execute()
        {
            if(_user.IsInRole(Role.ColorSoftAdministrator))
            {
                return _connection.Db().Organizations.All().OrderByName();
            }
            if(_user.IsInRole(Role.OrganizationAdministrator) && _user.OrganizationId.HasValue)
            {
                var organizationId = _user.OrganizationId.Value;
                return _connection.Db().Organizations.FindAllById(organizationId);
            }
            return Enumerable.Empty<Organization>();
        }
    }
}