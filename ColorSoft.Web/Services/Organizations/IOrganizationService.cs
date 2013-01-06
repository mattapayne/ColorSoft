using System;
using System.Collections.Generic;
using ColorSoft.Web.Data.Models;

namespace ColorSoft.Web.Services.Organizations
{
    public interface IOrganizationService : IApplicationService
    {
        IEnumerable<Organization> GetAll();
        void Create(Organization org);
        Organization GetById(Guid id);
        void Update(Organization organization);
        void Delete(params Guid[] ids);
    }
}
