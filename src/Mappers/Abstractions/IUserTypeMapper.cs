using System.Collections.Generic;
using AlbedoTeam.Identity.Contracts.Commands;
using AlbedoTeam.Identity.Contracts.Requests;
using AlbedoTeam.Identity.Contracts.Responses;
using Identity.Api.Models;
using Identity.Api.Services.UserTypeService.Requests;

namespace Identity.Api.Mappers.Abstractions
{
    public interface IUserTypeMapper
    {
        // Broker to Model
        UserType MapResponseToModel(UserTypeResponse response);
        List<UserType> MapResponseToModel(List<UserTypeResponse> response);

        // MediatR to Broker
        CreateUserType MapRequestToBroker(Create request);
        DeleteUserType MapRequestToBroker(Delete request);
        UpdateUserType MapRequestToBroker(Update request);
        GetUserType MapRequestToBroker(Get request);
        ListUserTypes MapRequestToBroker(List request);

        // MediatR to Broker Commands
        AddGroupToUserType MapRequestToCommand(AddGroup request);
        RemoveGroupFromUserType MapRequestToCommand(RemoveGroup request);
    }
}