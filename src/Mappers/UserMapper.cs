using System.Collections.Generic;
using AlbedoTeam.Identity.Contracts.Commands;
using AlbedoTeam.Identity.Contracts.Requests;
using AlbedoTeam.Identity.Contracts.Responses;
using AutoMapper;
using Identity.Api.Mappers.Abstractions;
using Identity.Api.Models;
using Identity.Api.Services.UserService.Requests;

namespace Identity.Api.Mappers
{
    public class UserMapper : IUserMapper
    {
        private readonly IMapper _mapper;

        public UserMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Broker to Model
                cfg.CreateMap<User, UserResponse>().ReverseMap();

                // MediatR to Broker
                cfg.CreateMap<Create, CreateUser>().ReverseMap();
                cfg.CreateMap<Delete, DeleteUser>().ReverseMap();
                cfg.CreateMap<Update, UpdateUser>().ReverseMap();
                cfg.CreateMap<Get, GetUser>().ReverseMap();
                cfg.CreateMap<List, ListUsers>().ReverseMap();
            });

            _mapper = config.CreateMapper();
        }

        public User MapResponseToModel(UserResponse response)
        {
            return _mapper.Map<UserResponse, User>(response);
        }

        public List<User> MapResponseToModel(List<UserResponse> response)
        {
            return _mapper.Map<List<UserResponse>, List<User>>(response);
        }

        public CreateUser MapRequestToBroker(Create request)
        {
            return _mapper.Map<Create, CreateUser>(request);
        }

        public DeleteUser MapRequestToBroker(Delete request)
        {
            return _mapper.Map<Delete, DeleteUser>(request);
        }

        public UpdateUser MapRequestToBroker(Update request)
        {
            return _mapper.Map<Update, UpdateUser>(request);
        }

        public GetUser MapRequestToBroker(Get request)
        {
            return _mapper.Map<Get, GetUser>(request);
        }

        public ListUsers MapRequestToBroker(List request)
        {
            return _mapper.Map<List, ListUsers>(request);
        }

        public ActivateUser MapRequestToCommand(Activate request)
        {
            return _mapper.Map<Activate, ActivateUser>(request);
        }

        public DeactivateUser MapRequestToCommand(Deactivate request)
        {
            return _mapper.Map<Deactivate, DeactivateUser>(request);
        }

        public SetUserPassword MapRequestToCommand(SetPassword request)
        {
            return _mapper.Map<SetPassword, SetUserPassword>(request);
        }

        public ChangeUserPassword MapRequestToCommand(ChangePassword request)
        {
            return _mapper.Map<ChangePassword, ChangeUserPassword>(request);
        }

        public ExpireUserPassword MapRequestToCommand(ExpirePassword request)
        {
            return _mapper.Map<ExpirePassword, ExpireUserPassword>(request);
        }

        public ClearUserSessions MapRequestToCommand(ClearSessions request)
        {
            return _mapper.Map<ClearSessions, ClearUserSessions>(request);
        }
    }
}