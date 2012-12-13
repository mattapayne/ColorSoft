using System;
using System.Web.Security;
using ColorSoft.Web.Queries.Users;

namespace ColorSoft.Web.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthCookieService _formsAuthenticationCookieDataProvider;
        private readonly IGetUserByUsernameQuery _getUserByUsernameQuery;
        private readonly IPasswordService _passwordService;

        public AuthenticationService(
            IPasswordService passwordService,
            IAuthCookieService formsAuthenticationCookieDataProvider,
            IGetUserByUsernameQuery getUserByUsernameQuery)
        {
            _passwordService = passwordService;
            _formsAuthenticationCookieDataProvider = formsAuthenticationCookieDataProvider;
            _getUserByUsernameQuery = getUserByUsernameQuery;
        }

        #region IAuthenticationService Members

        public bool Authenticate(string userName, string password)
        {
            var user = _getUserByUsernameQuery.Execute(userName);
            return user != null && _passwordService.Matches(password, user.HashedPassword);
        }

        public void SetAuthCookie(string userName, bool persistent)
        {
            var user = _getUserByUsernameQuery.Execute(userName, includeRoles: true);

            if (user == null)
            {
                throw new InvalidOperationException("Unable to set auth cookie when user cannot be located.");
            }

            string userData = _formsAuthenticationCookieDataProvider.ProvideUserData(user);
            FormsAuthentication.SetAuthCookie(userData, persistent);
        }

        public string DefaultUrl
        {
            get { return FormsAuthentication.DefaultUrl; }
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        #endregion
    }
}