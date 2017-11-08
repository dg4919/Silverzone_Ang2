using System.Linq;
using Autofac;
using System.Reflection;

namespace Silverzone.Api.Modules
{
    public class RepositoryModule:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("Silverzone.Data"))
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces()
                  .InstancePerLifetimeScope();
        }
    }
}