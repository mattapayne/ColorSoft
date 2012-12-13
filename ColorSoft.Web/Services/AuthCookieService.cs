using System;
using System.Linq;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Infrastructure.Authentication;

namespace ColorSoft.Web.Services
{
    public class AuthCookieService : IAuthCookieService
    {
        #region IAuthCookieService Members

        public string ProvideUserData(User user)
        {
            return String.Format("{0}^{1}^{2}^{3}", user.Id,
                                 user.OrganizationId.HasValue ? user.OrganizationId.Value.ToString() : "none",
                                 String.Format("{0} {1}", user.FirstName, user.LastName),
                                 String.Join("$", user.Roles.ToArray()));
        }

        public ColorSoftIdentity ConstructIdentity(string data)
        {
            if (String.IsNullOrEmpty(data))
            {
                return new ColorSoftIdentity(null, null, null, null);
            }

            var tokens =
                data.Split(new[] {'^'}, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()).ToArray();

            var roles = tokens.Count() == 4
                                            ? tokens[3].Split(new[] {'$'}, StringSplitOptions.RemoveEmptyEntries).Select
                                                  (s => s.Trim()).ToList()
                                            : Enumerable.Empty<string>();

            var userId = new Guid(tokens[0]);
            Guid? orgId = null;
            Guid attemptedOrgId;

            if(Guid.TryParse(tokens[1], out attemptedOrgId))
            {
                orgId = attemptedOrgId;
            }

            return new ColorSoftIdentity(userId, orgId, tokens[2], roles);
        }

        #endregion
    }
}