using System.Web.Http.Filters;
using System.Web.Mvc;

namespace ColorSoft.Web.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterWebApiFilters(HttpFilterCollection filters)
        {
        }
    }
}