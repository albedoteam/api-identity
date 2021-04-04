namespace Identity.Api.Mappers
{
    using System.Collections.Generic;
    using Abstractions;
    using AlbedoTeam.Identity.Contracts.Commands;
    using AlbedoTeam.Identity.Contracts.Requests;
    using AlbedoTeam.Identity.Contracts.Responses;
    using AutoMapper;
    using Models;
    using Services.UserTypeService.Requests;

    public class UserTypeMapper : IUserTypeMapper
    {
        private readonly IMapper _mapper;

        public UserTypeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Broker Responses to Model
                cfg.CreateMap<UserType, UserTypeResponse>().ReverseMap();

                // MediatR to Broker Requests
                cfg.CreateMap<Create, CreateUserType>().ReverseMap();
                cfg.CreateMap<Delete, DeleteUserType>().ReverseMap();
                cfg.CreateMap<Update, UpdateUserType>().ReverseMap();
                cfg.CreateMap<Get, GetUserType>().ReverseMap();
                cfg.CreateMap<List, ListUserTypes>().ReverseMap();

                // MediatR to Broker Commands
                cfg.CreateMap<AddGroup, AddGroupToUserType>().ReverseMap();
                cfg.CreateMap<RemoveGroup, RemoveGroupFromUserType>().ReverseMap();
            });

            _mapper = config.CreateMapper();
        }

        public UserType MapResponseToModel(UserTypeResponse response)
        {
            return _mapper.Map<UserTypeResponse, UserType>(response);
        }

        public List<UserType> MapResponseToModel(List<UserTypeResponse> response)
        {
            return _mapper.Map<List<UserTypeResponse>, List<UserType>>(response);
        }

        public CreateUserType MapRequestToBroker(Create request)
        {
            return _mapper.Map<Create, CreateUserType>(request);
        }

        public DeleteUserType MapRequestToBroker(Delete request)
        {
            return _mapper.Map<Delete, DeleteUserType>(request);
        }

        public UpdateUserType MapRequestToBroker(Update request)
        {
            return _mapper.Map<Update, UpdateUserType>(request);
        }

        public GetUserType MapRequestToBroker(Get request)
        {
            return _mapper.Map<Get, GetUserType>(request);
        }

        public ListUserTypes MapRequestToBroker(List request)
        {
            return _mapper.Map<List, ListUserTypes>(request);
        }

        public AddGroupToUserType MapRequestToCommand(AddGroup request)
        {
            return _mapper.Map<AddGroup, AddGroupToUserType>(request);
        }

        public RemoveGroupFromUserType MapRequestToCommand(RemoveGroup request)
        {
            return _mapper.Map<RemoveGroup, RemoveGroupFromUserType>(request);
        }
    }
}