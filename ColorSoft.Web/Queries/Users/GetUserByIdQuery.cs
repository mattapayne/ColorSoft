using System;
using ColorSoft.Web.Data;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Queries.Users
{
    public class GetUserByIdQuery : IGetUserByIdQuery
    {
        private readonly IDatabaseProvider _connection;

        public GetUserByIdQuery(IDatabaseProvider connection)
        {
            _connection = connection;
        }

        #region IGetUserByIdQuery Members

        public User Execute(Guid id)
        {
            return _connection.Db().Users.FindAllById(id).FirstOrDefault();
        }

        #endregion
    }
}