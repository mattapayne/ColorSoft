using Autofac;
using ColorSoft.Web.Commands;

namespace ColorSoft.Web.Infrastructure.Modules
{
    public class CommandsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof (MvcApplication).Assembly).AssignableTo<ICommand>().
                AsImplementedInterfaces();
        }
    }
}