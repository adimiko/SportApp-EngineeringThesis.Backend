using System.Reflection;
using Autofac;
using Infrastructure.Dapper;

namespace Infrastructure.IoC.Modules
{
    public class DapperModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(DapperModule)
                .GetTypeInfo()
                .Assembly;
    
            builder.RegisterAssemblyTypes(assembly)
                    .Where(x => x.IsAssignableTo<IDapperRepository>())
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
        }
    }
}