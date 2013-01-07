using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Queries.Users
{
    public interface IGetUserByEmailQuery : IQuery
    {
        User Execute(string emailAddress);
    }
}
