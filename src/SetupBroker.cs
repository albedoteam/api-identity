using AlbedoTeam.Identity.Contracts.Commands;
using AlbedoTeam.Identity.Contracts.Requests;
using AlbedoTeam.Sdk.MessageProducer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Api
{
    public static class SetupBroker
    {
        public static IServiceCollection ConfigureBroker(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddProducer(
                configure =>
                {
                    configure
                        .SetBrokerOptions(broker => broker.Host = configuration.GetValue<string>("Broker:Host"));
                },
                consumers =>
                {
                    // if listening to events is necessary, set up consumers here
                },
                queues =>
                {
                    // auth server commands
                    queues
                        .Map<ActivateAuthServer>()
                        .Map<DeactivateAuthServer>();

                    // user commands
                    queues
                        .Map<ActivateUser>()
                        .Map<DeactivateUser>()
                        .Map<SetUserPassword>()
                        .Map<ChangeUserPassword>()
                        .Map<ExpireUserPassword>()
                        .Map<ClearUserSessions>();
                },
                clients =>
                {
                    // auth server
                    clients
                        .Add<ListAuthServers>()
                        .Add<GetAuthServer>()
                        .Add<CreateAuthServer>()
                        .Add<DeleteAuthServer>();

                    // group
                    clients
                        .Add<ListGroups>()
                        .Add<GetGroup>()
                        .Add<CreateGroup>()
                        .Add<UpdateGroup>()
                        .Add<DeleteGroup>();

                    // user type
                    clients
                        .Add<ListUserTypes>()
                        .Add<GetUserType>()
                        .Add<CreateUserType>()
                        .Add<DeleteUserType>();

                    // user
                    clients
                        .Add<ListUsers>()
                        .Add<GetUser>()
                        .Add<CreateUser>()
                        .Add<UpdateUser>()
                        .Add<DeleteUser>();
                });

            return services;
        }
    }
}