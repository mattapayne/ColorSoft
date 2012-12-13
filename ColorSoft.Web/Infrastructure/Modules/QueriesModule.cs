using Autofac;
using ColorSoft.Web.Queries;

namespace ColorSoft.Web.Infrastructure.Modules
{
    public class QueriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof (MvcApplication).Assembly).AssignableTo<IQuery>().
                AsImplementedInterfaces();
        }
    }
}