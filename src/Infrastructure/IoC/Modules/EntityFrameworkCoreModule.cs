using System.Reflection;
using Autofac;
using Infrastructure.EntityFrameworkCore;

namespace Infrastructure.IoC.Modules
{
    public class EntityFrameworkCoreModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(EntityFrameworkCoreModule)
                .GetTypeInfo()
                .Assembly;
    
            builder.RegisterAssemblyTypes(assembly)
                    .Where(x => x.IsAssignableTo<IEntityFrameworkCoreRepository>())
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
        }
    }
}