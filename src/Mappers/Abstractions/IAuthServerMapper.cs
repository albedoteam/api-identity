namespace Identity.Api.Mappers.Abstractions
{
    using System.Collections.Generic;
    using AlbedoTeam.Identity.Contracts.Commands;
    using AlbedoTeam.Identity.Contracts.Requests;
    using AlbedoTeam.Identity.Contracts.Responses;
    using Models;
    using Services.AuthServerService.Requests;

    public interface IAuthServerMapper
    {
        // Broker to Model
        AuthServer MapResponseToModel(AuthServerResponse response);
        List<AuthServer> MapResponseToModel(List<AuthServerResponse> response);

        // MediatR to Broker
        CreateAuthServer MapRequestToBroker(Create request);
        DeleteAuthServer MapRequestToBroker(Delete request);
        GetAuthServer MapRequestToBroker(Get request);
        ListAuthServers MapRequestToBroker(List request);
        UpdateAuthServer MapRequestToBroker(Update request);

        // MediatR to Broker Commands
        ActivateAuthServer MapRequestToCommand(Activate request);
        DeactivateAuthServer MapRequestToCommand(Deactivate request);
    }
}