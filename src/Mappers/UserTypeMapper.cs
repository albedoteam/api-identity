using System.Collections.Generic;
using AlbedoTeam.Identity.Contracts.Requests;
using AlbedoTeam.Identity.Contracts.Responses;
using AutoMapper;
using Identity.Api.Mappers.Abstractions;
using Identity.Api.Models;
using Identity.Api.Services.UserTypeService.Requests;

namespace Identity.Api.Mappers
{
    public class UserTypeMapper : IUserTypeMapper
    {
        private readonly IMapper _mapper;

        public UserTypeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Broker to Model
                cfg.CreateMap<UserType, UserTypeResponse>().ReverseMap();

                // MediatR to Broker
                cfg.CreateMap<Create, CreateUserType>().ReverseMap();
                cfg.CreateMap<Delete, DeleteUserType>().ReverseMap();
                cfg.CreateMap<Get, GetUserType>().ReverseMap();
                cfg.CreateMap<List, ListUserTypes>().ReverseMap();
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

        public GetUserType MapRequestToBroker(Get request)
        {
            return _mapper.Map<Get, GetUserType>(request);
        }

        public ListUserTypes MapRequestToBroker(List request)
        {
            return _mapper.Map<List, ListUserTypes>(request);
        }
    }
}