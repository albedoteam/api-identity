using System.Collections.Generic;
using AlbedoTeam.Identity.Contracts.Requests;
using AlbedoTeam.Identity.Contracts.Responses;
using Identity.Api.Models;
using Identity.Api.Services.GroupService.Requests;

namespace Identity.Api.Mappers.Abstractions
{
    public interface IGroupMapper
    {
        // Broker to Model
        Group MapResponseToModel(GroupResponse response);
        List<Group> MapResponseToModel(List<GroupResponse> response);

        // MediatR to Broker
        CreateGroup MapRequestToBroker(Create request);
        DeleteGroup MapRequestToBroker(Delete request);
        UpdateGroup MapRequestToBroker(Update request);
        GetGroup MapRequestToBroker(Get request);
        ListGroups MapRequestToBroker(List request);
    }
}