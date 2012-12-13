using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Queries.Users
{
    public interface IGetUserByUsernameQuery : IQuery
    {
        User Execute(string userName, bool includeRoles = false);
    }
}