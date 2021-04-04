namespace Identity.Api.Mappers.Abstractions
{
    using AlbedoTeam.Identity.Contracts.Commands;
    using AlbedoTeam.Identity.Contracts.Requests;
    using AlbedoTeam.Identity.Contracts.Responses;
    using Models;
    using Services.PasswordRecoveryService.Requests;

    public interface IPasswordRecoveryMapper
    {
        // Broker to Model
        PasswordRecovery MapResponseToModel(PasswordRecoveryResponse response);

        // MediatR to Broker 
        GetPasswordRecovery MapRequestToBroker(Get request);
        CreatePasswordRecovery MapRequestToCommand(Create create);
    }
}