﻿using System.Collections.Generic;
using AlbedoTeam.Identity.Contracts.Commands;
using AlbedoTeam.Identity.Contracts.Requests;
using AlbedoTeam.Identity.Contracts.Responses;
using Identity.Api.Models;
using Identity.Api.Services.UserService.Requests;
using Get = Identity.Api.Services.UserService.Requests.Get;

namespace Identity.Api.Mappers.Abstractions
{
    public interface IUserMapper
    {
        // Broker to Model
        User MapResponseToModel(UserResponse response);
        List<User> MapResponseToModel(List<UserResponse> response);

        // MediatR to Broker
        CreateUser MapRequestToBroker(Create request);
        DeleteUser MapRequestToBroker(Delete request);
        UpdateUser MapRequestToBroker(Update request);
        GetUser MapRequestToBroker(Get request);
        ListUsers MapRequestToBroker(List request);

        // MediatR to Broker Commands
        ActivateUser MapRequestToCommand(Activate request);
        DeactivateUser MapRequestToCommand(Deactivate request);
        SetUserPassword MapRequestToCommand(SetPassword request);
        ChangeUserPassword MapRequestToCommand(ChangePassword request);
        ExpireUserPassword MapRequestToCommand(ExpirePassword request);
        ClearUserSessions MapRequestToCommand(ClearSessions request);
        AddGroupToUser MapRequestToCommand(AddGroup request);
        RemoveGroupFromUser MapRequestToCommand(RemoveGroup request);
        ChangeUserTypeOnUser MapRequestToCommand(ChangeUserType request);
    }
}