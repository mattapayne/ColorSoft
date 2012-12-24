using System.Web;
using Autofac;
using ColorSoft.Web.Infrastructure.Authentication;

namespace ColorSoft.Web.Infrastructure.Modules
{
    public class IdentityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => HttpContext.Current.User as IApplicationUser);
        }
    }
}