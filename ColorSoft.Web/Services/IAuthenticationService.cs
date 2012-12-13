namespace ColorSoft.Web.Services
{
    public interface IAuthenticationService : IApplicationService
    {
        string DefaultUrl { get; }
        bool Authenticate(string username, string password);
        void SetAuthCookie(string username, bool rememberMe);
        void SignOut();
    }
}