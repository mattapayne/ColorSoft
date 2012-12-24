using System;
using System.Security.Principal;

namespace ColorSoft.Web.Infrastructure.Authentication
{
    public interface IApplicationUser : IPrincipal
    {
        Guid? Id { get; }
    }
}
