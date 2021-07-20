using Autofac;
using Infrastructure.IoC.Modules;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.IoC
{
    public class ContainerModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;
        public ContainerModule(IConfiguration configuration)
            => _configuration = configuration;


        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<RepositoryModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule(new SettingsModule(_configuration));
            builder.RegisterModule<MapperModule>();
            builder.RegisterModule<CommandModule>();
            builder.RegisterModule<QueryModule>();
            builder.RegisterModule<DapperModule>();
            builder.RegisterModule<EntityFrameworkCoreModule>();
            //builder.RegisterModule<DapperAndEntityFrameworkCoreModule>();
        }
    }
}