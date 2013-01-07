using ColorSoft.Web.Data;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Queries.Users
{
    public class GetUserByEmailQuery : IGetUserByEmailQuery
    {
        private readonly IDatabaseProvider _connection;

        public GetUserByEmailQuery(IDatabaseProvider connection)
        {
            _connection = connection;
        }

        public User Execute(string emailAddress)
        {
            return _connection.Db().Users.FindAllByEmailAddress(emailAddress).FirstOrDefault();  
        }
    }
}