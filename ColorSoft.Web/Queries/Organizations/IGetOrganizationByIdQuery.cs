using System;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Queries.Organizations
{
    public interface IGetOrganizationByIdQuery : IQuery
    {
        Organization Execute(Guid id);
    }
}
