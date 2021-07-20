using System.Reflection;
using Application.Queries;
using Autofac;

namespace Infrastructure.IoC.Modules
{
    public class QueryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(IQuery<>)
                .GetTypeInfo()
                .Assembly;
            
            builder.RegisterAssemblyTypes(assembly).Where(x => x.IsAssignableTo<IQueryDispatcher>())
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly)
                   .AsClosedTypesOf(typeof(IQueryHandler<,>))
                   .InstancePerLifetimeScope();
        }
    }
}