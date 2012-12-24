using System;
using System.Linq;
using System.Security.Principal;

namespace ColorSoft.Web.Infrastructure.Authentication
{
    public class ColorSoftPrincipal : IApplicationUser
    {
        private readonly ColorSoftIdentity _identity;

        public ColorSoftPrincipal(ColorSoftIdentity identity)
        {
            _identity = identity;
        }

        #region IPrincipal Members

        public bool IsInRole(string role)
        {
            return _identity.Roles.Any(r => r == role);
        }

        public IIdentity Identity
        {
            get { return _identity; }
        }

        #endregion

        public Guid? Id
        {
            get { return _identity.Id; }
        }
    }
}