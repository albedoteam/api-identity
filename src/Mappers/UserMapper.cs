namespace Identity.Api.Mappers
{
    using System.Collections.Generic;
    using Abstractions;
    using AlbedoTeam.Identity.Contracts.Commands;
    using AlbedoTeam.Identity.Contracts.Requests;
    using AlbedoTeam.Identity.Contracts.Responses;
    using AutoMapper;
    using Models;
    using Services.UserService.Requests;

    public class UserMapper : IUserMapper
    {
        private readonly IMapper _mapper;

        public UserMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Broker Responses to Model
                cfg.CreateMap<User, UserResponse>().ReverseMap();

                // MediatR to Broker Requests
                cfg.CreateMap<Create, CreateUser>().ReverseMap();
                cfg.CreateMap<Delete, DeleteUser>().ReverseMap();
                cfg.CreateMap<Update, UpdateUser>().ReverseMap();
                cfg.CreateMap<Get, GetUser>().ReverseMap();
                cfg.CreateMap<List, ListUsers>().ReverseMap();

                // MediatR to Broker Commands
                cfg.CreateMap<Activate, ActivateUser>().ReverseMap();
                cfg.CreateMap<Deactivate, DeactivateUser>().ReverseMap();
                cfg.CreateMap<SetPassword, SetUserPassword>().ReverseMap();
                cfg.CreateMap<ChangePassword, ChangeUserPassword>().ReverseMap();
                cfg.CreateMap<ExpirePassword, ExpireUserPassword>().ReverseMap();
                cfg.CreateMap<ClearSessions, ClearUserSessions>().ReverseMap();
                cfg.CreateMap<AddGroup, AddGroupToUser>().ReverseMap();
                cfg.CreateMap<RemoveGroup, RemoveGroupFromUser>().ReverseMap();
                cfg.CreateMap<ChangeUserType, ChangeUserTypeOnUser>().ReverseMap();
                cfg.CreateMap<ResendInvite, ResendFirstAccessEmail>().ReverseMap();
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

        public AddGroupToUser MapRequestToCommand(AddGroup request)
        {
            return _mapper.Map<AddGroup, AddGroupToUser>(request);
        }

        public RemoveGroupFromUser MapRequestToCommand(RemoveGroup request)
        {
            return _mapper.Map<RemoveGroup, RemoveGroupFromUser>(request);
        }

        public ChangeUserTypeOnUser MapRequestToCommand(ChangeUserType request)
        {
            return _mapper.Map<ChangeUserType, ChangeUserTypeOnUser>(request);
        }

        public ResendFirstAccessEmail MapRequestToCommand(ResendInvite request)
        {
            return _mapper.Map<ResendInvite, ResendFirstAccessEmail>(request);
        }
    }
}