using System.Reflection;
using AutoMapper;
using Autofac;
using Module = Autofac.Module;

namespace ColorSoft.Web.Infrastructure.Modules
{
    public class AutoMapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AssignableTo<Profile>().As<Profile>();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => (typeof(IValueResolver).IsAssignableFrom(t)));
            builder.Register(c => Mapper.Engine).As<IMappingEngine>();
        }
    }
}