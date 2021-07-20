using Microsoft.Extensions.Configuration;

namespace Infrastructure.Extensions
{
    public static class SettingsExtensions
    {
        public static T GetSettings<T>(this IConfiguration configuration) where T : new()
        {
            var configurationValue = new T();
            configuration.GetSection(typeof(T).Name).Bind(configurationValue);
            return configurationValue;
        }
    }
}