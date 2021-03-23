using Identity.Api.Mappers.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Api.Mappers
{
    public static class Setup
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddTransient<IAuthServerMapper, AuthServerMapper>();
            services.AddTransient<IGroupMapper, GroupMapper>();
            services.AddTransient<IUserTypeMapper, UserTypeMapper>();
            services.AddTransient<IUserMapper, UserMapper>();
            services.AddTransient<IPasswordRecoveryMapper, PasswordRecoveryMapper>();

            return services;
        }
    }
}