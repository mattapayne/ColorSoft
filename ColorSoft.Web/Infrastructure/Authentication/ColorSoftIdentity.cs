using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace ColorSoft.Web.Infrastructure.Authentication
{
    [Serializable]
    [ComVisible(true)]
    public sealed class ColorSoftIdentity : IIdentity
    {
        private readonly Guid? _id;
        private readonly Guid? _organizationId;
        private readonly string _name;
        private readonly IEnumerable<string> _roles;

        public ColorSoftIdentity(Guid? id, Guid? organizationId, string name, IEnumerable<string> roles)
        {
            _id = id;
            _organizationId = organizationId;
            _name = name ?? String.Empty;
            _roles = roles ?? Enumerable.Empty<string>();
        }

        public IEnumerable<string> Roles
        {
            get { return new ReadOnlyCollection<string>(_roles.ToList()); }
        }

        public Guid? Id
        {
            get { return _id; }
        }

        public Guid? OrganizationId
        {
            get { return _organizationId; }
        }

        #region IIdentity Members

        public string Name
        {
            get { return _name; }
        }

        public string AuthenticationType
        {
            get { return "ColorSoft Forms Authentication"; }
        }

        public bool IsAuthenticated
        {
            get { return _id.HasValue && !String.IsNullOrEmpty(_name); }
        }

        #endregion
    }
}