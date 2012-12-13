using System.Configuration;
using Autofac;
using ColorSoft.Web.Data;

namespace ColorSoft.Web.Infrastructure.Modules
{
    public class SimpleDataModule : Module
    {
        private const string ConnectionStringKey = "ColorSoft";

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SimpleDbDatabaseProvider>().
                As<IDatabaseProvider>().
                SingleInstance().
                WithParameter("connectionString",
                              ConfigurationManager.ConnectionStrings[ConnectionStringKey].ConnectionString);
        }
    }
}