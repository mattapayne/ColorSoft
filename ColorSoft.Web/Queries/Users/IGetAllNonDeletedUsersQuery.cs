using System.Collections.Generic;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Queries.Users
{
    public interface IGetAllNonDeletedUsersQuery : IQuery
    {
        IEnumerable<User> Execute();
    }
}