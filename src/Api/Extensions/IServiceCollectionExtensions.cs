using System.Text;
using Api.Policies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Api.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddJwt(this IServiceCollection services, string secretKey)
        {
            var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = false,
                    ValidateLifetime = true
                };

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.SaveToken = true;
                x.TokenValidationParameters = tokenValidationParameters;
            });
        }

        public static void AddAuthorizationWithConfiguration(this IServiceCollection services)
        {
            services.AddAuthorization(p => p.AddPolicy(Policy.User ,p => p.RequireRole(Policy.User)));
            services.AddAuthorization(p => p.AddPolicy(Policy.Admin ,p => p.RequireRole(Policy.Admin)));
        }
    }
}