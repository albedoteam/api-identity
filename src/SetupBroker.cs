﻿namespace Identity.Api
{
    using AlbedoTeam.Identity.Contracts.Commands;
    using AlbedoTeam.Identity.Contracts.Requests;
    using AlbedoTeam.Sdk.MessageConsumer.Configuration;
    using AlbedoTeam.Sdk.MessageProducer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class SetupBroker
    {
        public static IServiceCollection ConfigureBroker(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddProducer(
                configure =>
                {
                    configure.SetBrokerOptions(broker =>
                    {
                        broker.HostOptions = new HostOptions
                        {
                            Host = configuration.GetValue<string>("Broker_Host"),
                            HeartbeatInterval = 10,
                            RequestedChannelMax = 40,
                            RequestedConnectionTimeout = 60000
                        };

                        broker.KillSwitchOptions = new KillSwitchOptions
                        {
                            ActivationThreshold = 10,
                            TripThreshold = 0.15,
                            RestartTimeout = 60
                        };

                        broker.PrefetchCount = 1;
                    });
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

                    // userTypes commands
                    queues
                        .Map<AddGroupToUserType>()
                        .Map<RemoveGroupFromUserType>();

                    // user commands
                    queues
                        .Map<ActivateUser>()
                        .Map<DeactivateUser>()
                        .Map<SetUserPassword>()
                        .Map<ChangeUserPassword>()
                        .Map<ExpireUserPassword>()
                        .Map<ClearUserSessions>()
                        .Map<AddGroupToUser>()
                        .Map<RemoveGroupFromUser>()
                        .Map<ChangeUserTypeOnUser>()
                        .Map<ResendFirstAccessEmail>();

                    // pwd recovery commands
                    queues
                        .Map<CreatePasswordRecovery>();
                },
                clients =>
                {
                    // auth server
                    clients
                        .Add<ListAuthServers>()
                        .Add<GetAuthServer>()
                        .Add<CreateAuthServer>()
                        .Add<UpdateAuthServer>()
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
                        .Add<DeleteUserType>()
                        .Add<UpdateUserType>();

                    // user
                    clients
                        .Add<ListUsers>()
                        .Add<GetUser>()
                        .Add<CreateUser>()
                        .Add<UpdateUser>()
                        .Add<DeleteUser>();

                    // pwd recovery
                    clients
                        .Add<GetPasswordRecovery>();
                });

            return services;
        }
    }
}