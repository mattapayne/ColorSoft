using Autofac;

namespace ColorSoft.Web.Infrastructure
{
    public interface IContainerAccessProvider
    {
        IContainer GetContainer();
    }
}