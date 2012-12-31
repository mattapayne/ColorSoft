using System.Web;
using System.Web.Mvc;

namespace ColorSoft.Web.Services
{
    public class TemplateUrlGenerationService : ITemplateUrlGenerationService
    {
        private readonly HttpContextBase _httpContextBase;

        public TemplateUrlGenerationService(HttpContextBase httpContextBase)
        {
            _httpContextBase = httpContextBase;
        }

        public string Generate(string name)
        {
            var url = new UrlHelper(_httpContextBase.Request.RequestContext);
            return url.Action(name, MVC.Templates.Name);
        }
    }
}