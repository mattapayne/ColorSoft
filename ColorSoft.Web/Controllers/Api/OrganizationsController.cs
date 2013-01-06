using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Filters;
using ColorSoft.Web.Models.Api.Organizations;
using ColorSoft.Web.Services.Organizations;

namespace ColorSoft.Web.Controllers.Api
{
    public class OrganizationsController : AuthenticatedApiController
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationsController(IOrganizationService organizationService, IMappingEngine mappingEngine)
            : base(mappingEngine)
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        [Authorize(Roles = Role.AnyAdministrator)]
        public IEnumerable<OrganizationViewModel> Index()
        {
            var organizations = _organizationService.GetAll();
            return MappingEngine.Map<IEnumerable<Organization>, IEnumerable<OrganizationViewModel>>(organizations);
        }

        [HttpPost]
        [Authorize(Roles = Role.ColorSoftAdministrator)]
        [ModelRequired]
        public HttpResponseMessage Create(AddOrganizationViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var org = MappingEngine.Map<AddOrganizationViewModel, Organization>(model);
                    _organizationService.Create(org);
                    return CreatedResponse(org.Id);
                }
                catch (Exception ex)
                {
                    return ExceptionErrorResponse(ex);
                }
            }

            return ModelStateErrorResponse();
        }

        [HttpPut]
        [Authorize(Roles = Role.ColorSoftAdministrator)]
        [ModelRequired]
        public HttpResponseMessage Update(OrganizationViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var organization = _organizationService.GetById(model.Id);
                    MappingEngine.Map(model, organization);
                    _organizationService.Update(organization);
                    return UpdatedResponse();
                }
                catch (Exception ex)
                {
                    return ExceptionErrorResponse(ex);
                }
            }

            return ModelStateErrorResponse();
        }

        [HttpPost]
        [Authorize(Roles = Role.ColorSoftAdministrator)]
        [ModelRequired(ModelParameterName = "ids")]
        public HttpResponseMessage Delete(Guid[] ids)
        {
            try
            {
                _organizationService.Delete(ids);
                return DeletedResponse();
            }
            catch (Exception ex)
            {
                return ExceptionErrorResponse(ex);
            }
        }
    }
}
