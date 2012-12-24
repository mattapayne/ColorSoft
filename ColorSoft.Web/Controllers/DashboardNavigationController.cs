using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using ColorSoft.Web.Data.Models;
using ColorSoft.Web.Models.DashboardNavigation;
using ColorSoft.Web.Queries.DashboardNavigation;

namespace ColorSoft.Web.Controllers
{
    [Authorize]
    public partial class DashboardNavigationController : AbstractController
    {
        private readonly IGetDashboardNavigationQuery _getDashboardNavigationQuery;
        private readonly IMappingEngine _mappingEngine;

        public DashboardNavigationController(IGetDashboardNavigationQuery getDashboardNavigationQuery, IMappingEngine mappingEngine)
        {
            _getDashboardNavigationQuery = getDashboardNavigationQuery;
            _mappingEngine = mappingEngine;
        }

        [ChildActionOnly]
        public virtual ActionResult Index()
        {
            var sections = _getDashboardNavigationQuery.Execute();

            var modelSections =
                sections.
                    OrderBy(x => x.SortOrder).
                    Select(
                        section =>
                        _mappingEngine.Map<DashboardNavigationSection, DashboardNavigationSectionViewModel>(section)).
                    ToList();

            var model = new DashboardNavigationViewModel { Sections = modelSections };
            return PartialView(MVC.DashboardNavigation.Views._Index, model);
        }
    }
}