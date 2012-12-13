using System;
using System.Web.Configuration;
using System.Web.Security;

namespace ColorSoft.Web.Services
{
    public class PasswordService : IPasswordService
    {
        #region IPasswordService Members

        public string Generate(string clearTextPassword)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(clearTextPassword,
                                                                          FormsAuthPasswordFormat.MD5.ToString());
        }

        public bool Matches(string suppliedPassword, string hashedPassword)
        {
            var test = Generate(suppliedPassword);
            return string.Compare(test, hashedPassword, StringComparison.InvariantCultureIgnoreCase) == 0;
        }

        #endregion
    }
}