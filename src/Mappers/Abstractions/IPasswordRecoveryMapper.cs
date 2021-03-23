using AlbedoTeam.Identity.Contracts.Commands;
using AlbedoTeam.Identity.Contracts.Requests;
using AlbedoTeam.Identity.Contracts.Responses;
using Identity.Api.Models;
using Identity.Api.Services.PasswordRecoveryService.Requests;

namespace Identity.Api.Mappers.Abstractions
{
    public interface IPasswordRecoveryMapper
    {
        // Broker to Model
        PasswordRecovery MapResponseToModel(PasswordRecoveryResponse response);
        
        // MediatR to Broker 
        GetPasswordRecovery MapRequestToBroker(Get request);
        CreatePasswordRecovery MapRequestToCommand(Create create);
    }
}