using System.Web;
using Autofac;

namespace ColorSoft.Web.Infrastructure.Modules
{
    public class HttpRequestModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => HttpContext.Current.Request);
        }
    }
}