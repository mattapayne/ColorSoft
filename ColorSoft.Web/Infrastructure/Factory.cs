using Autofac;

namespace ColorSoft.Web.Infrastructure
{
    public class Factory<T> : IFactory<T> where T : class
    {
        private readonly IComponentContext _containerContext;

        public Factory(IComponentContext containerContext)
        {
            _containerContext = containerContext;
        }

        public T Construct()
        {
            return _containerContext.Resolve<T>();
        }
    }
}