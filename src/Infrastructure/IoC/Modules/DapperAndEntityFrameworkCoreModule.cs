using System.Reflection;
using Autofac;
using Infrastructure.Repositories.DapperAndEntityFrameworkCore;

namespace Infrastructure.IoC.Modules
{
    public class DapperAndEntityFrameworkCoreModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(DapperAndEntityFrameworkCoreModule)
                .GetTypeInfo()
                .Assembly;
    
            builder.RegisterAssemblyTypes(assembly)
                    .Where(x => x.IsAssignableTo<IDapperAndEntityFrameworkCoreRepository>())
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
        }
    }
}