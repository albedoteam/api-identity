namespace Identity.Api.Mappers
{
    using Abstractions;
    using Microsoft.Extensions.DependencyInjection;

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