using Autofac;
using ColorSoft.Web.Services;

namespace ColorSoft.Web.Infrastructure.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof (MvcApplication).Assembly).AssignableTo<IApplicationService>().
                AsImplementedInterfaces().InstancePerLifetimeScope();

            //builder.RegisterType<UrlGenerationService>().As<IUrlGenerationService>().InstancePerLifetimeScope();
        }
    }
}