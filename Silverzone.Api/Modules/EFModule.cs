using Autofac;
using Silverzone.Entities;

namespace Silverzone.Api.Modules
{
    public class EFModule:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(SilverzoneContext)).As(typeof(SilverzoneContext)).InstancePerLifetimeScope();

        }
    }
}