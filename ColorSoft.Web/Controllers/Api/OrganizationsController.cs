using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using ColorSoft.Web.Commands.Organizations;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Models.Api.Organizations;
using ColorSoft.Web.Queries.Organizations;

namespace ColorSoft.Web.Controllers.Api
{
    [Authorize(Roles = Role.AnyAdministrator)]
    public class OrganizationsController : AuthenticatedApiController
    {
        private readonly IGetOrganizationsQuery _getOrganizationsQuery;
        private readonly ICreateOrganizationCommand _createOrganizationCommand;
        private readonly IUpdateOrganizationCommand _updateOrganizationCommand;
        private readonly IGetOrganizationByIdQuery _getOrganizationByIdQuery;

        public OrganizationsController(IGetOrganizationsQuery getOrganizationsQuery,
            ICreateOrganizationCommand createOrganizationCommand,
            IUpdateOrganizationCommand updateOrganizationCommand,
            IGetOrganizationByIdQuery getOrganizationByIdQuery,
            IMappingEngine mappingEngine)
            : base(mappingEngine)
        {
            _getOrganizationsQuery = getOrganizationsQuery;
            _createOrganizationCommand = createOrganizationCommand;
            _updateOrganizationCommand = updateOrganizationCommand;
            _getOrganizationByIdQuery = getOrganizationByIdQuery;
        }

        [HttpGet]
        public IEnumerable<OrganizationViewModel> Index()
        {
            var organizations = _getOrganizationsQuery.Execute();
            return MappingEngine.Map<IEnumerable<Organization>, IEnumerable<OrganizationViewModel>>(organizations);
        }

        [HttpPost]
        [Authorize(Roles = Role.ColorSoftAdministrator)]
        public void Create(AddOrganizationViewModel model)
        {
            _createOrganizationCommand.Execute(MappingEngine.Map<AddOrganizationViewModel, Organization>(model));
        }

        [HttpPut]
        public void Update(OrganizationViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("model");
            }

            var organization = _getOrganizationByIdQuery.Execute(model.Id);
            MappingEngine.Map(model, organization);
            _updateOrganizationCommand.Execute(organization);
        }

        [HttpDelete]
        [Authorize(Roles = Role.ColorSoftAdministrator)]
        public void Delete(Guid id)
        {
            //TODO - Implement this - it must also delete all related data
        }

        [HttpPost]
        [Authorize(Roles = Role.ColorSoftAdministrator)]
        public void DeleteAll(Guid[] ids)
        {
            //TODO - Implement this - it must also delete all related data
        }
    }
}
