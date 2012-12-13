using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

namespace ColorSoft.Web.Infrastructure
{
    public static class Bootstrapper
    {
        public static IContainer Initialize()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof (MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof (MvcApplication).Assembly);
            builder.RegisterModule(new AutofacWebTypesModule());
            builder.RegisterAssemblyModules(typeof (MvcApplication).Assembly);

            var container = builder.Build();

            var autoMapperProfiles = container.Resolve<IEnumerable<Profile>>();
            Mapper.Initialize(m => autoMapperProfiles.ToList().ForEach(m.AddProfile));

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            return container;
        }
    }
}