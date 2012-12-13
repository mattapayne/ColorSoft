using System;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Queries.Users
{
    public interface IGetUserByIdQuery : IQuery
    {
        User Execute(Guid id);
    }
}