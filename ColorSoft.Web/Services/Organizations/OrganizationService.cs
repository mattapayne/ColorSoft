using System;
using System.Collections.Generic;
using System.Linq;
using ColorSoft.Web.Commands.Organizations;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Queries.Organizations;

namespace ColorSoft.Web.Services.Organizations
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IGetOrganizationsQuery _getOrganizationsQuery;
        private readonly ICreateOrganizationCommand _createOrganizationCommand;
        private readonly IUpdateOrganizationCommand _updateOrganizationCommand;
        private readonly IGetOrganizationByIdQuery _getOrganizationByIdQuery;
        private readonly IDeleteOrganizationCommand _deleteOrganizationCommand;

        public OrganizationService(IGetOrganizationByIdQuery getOrganizationByIdQuery, 
            IUpdateOrganizationCommand updateOrganizationCommand, 
            ICreateOrganizationCommand createOrganizationCommand, 
            IGetOrganizationsQuery getOrganizationsQuery, 
            IDeleteOrganizationCommand deleteOrganizationCommand)
        {
            _getOrganizationByIdQuery = getOrganizationByIdQuery;
            _updateOrganizationCommand = updateOrganizationCommand;
            _createOrganizationCommand = createOrganizationCommand;
            _getOrganizationsQuery = getOrganizationsQuery;
            _deleteOrganizationCommand = deleteOrganizationCommand;
        }

        public IEnumerable<Organization> GetAll()
        {
            return _getOrganizationsQuery.Execute();
        }

        public void Create(Organization org)
        {
            _createOrganizationCommand.Execute(org);
        }

        public Organization GetById(Guid id)
        {
            return _getOrganizationByIdQuery.Execute(id);
        }

        public void Update(Organization organization)
        {
            _updateOrganizationCommand.Execute(organization);
        }

        public void Delete(params Guid[] ids)
        {
            if(ids == null || !ids.Any())
            {
                return;
            }

            ids.ToList().ForEach(id => _deleteOrganizationCommand.Execute(id));
        }
    }
}