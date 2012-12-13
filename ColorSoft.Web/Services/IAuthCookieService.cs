using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Infrastructure.Authentication;

namespace ColorSoft.Web.Services
{
    public interface IAuthCookieService : IApplicationService
    {
        string ProvideUserData(User user);
        ColorSoftIdentity ConstructIdentity(string data);
    }
}