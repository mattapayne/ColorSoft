using Autofac;

namespace ColorSoft.Web.Infrastructure.Modules
{
    public class FactoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof (Factory<>)).As(typeof (IFactory<>));
        }
    }
}
