using System;
using ColorSoft.Web.Data;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Queries.Organizations
{
    public class GetOrganizationByIdQuery : IGetOrganizationByIdQuery
    {
        private readonly IDatabaseProvider _databaseProvider;

        public GetOrganizationByIdQuery(IDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public Organization Execute(Guid id)
        {
            return _databaseProvider.Db().Organizations.FindById(id);
        }
    }
}