﻿namespace Identity.Api.Mappers
{
    using System.Collections.Generic;
    using Abstractions;
    using AlbedoTeam.Identity.Contracts.Requests;
    using AlbedoTeam.Identity.Contracts.Responses;
    using AutoMapper;
    using Models;
    using Services.GroupService.Requests;

    public class GroupMapper : IGroupMapper
    {
        private readonly IMapper _mapper;

        public GroupMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Broker Responses to Model
                cfg.CreateMap<Group, GroupResponse>().ReverseMap();

                // MediatR to Broker Requests
                cfg.CreateMap<Create, CreateGroup>().ReverseMap();
                cfg.CreateMap<Delete, DeleteGroup>().ReverseMap();
                cfg.CreateMap<Update, UpdateGroup>().ReverseMap();
                cfg.CreateMap<Get, GetGroup>().ReverseMap();
                cfg.CreateMap<List, ListGroups>().ReverseMap();

                // MediatR to Broker Commands
                // ...
            });

            _mapper = config.CreateMapper();
        }

        public Group MapResponseToModel(GroupResponse response)
        {
            return _mapper.Map<GroupResponse, Group>(response);
        }

        public List<Group> MapResponseToModel(List<GroupResponse> response)
        {
            return _mapper.Map<List<GroupResponse>, List<Group>>(response);
        }

        public CreateGroup MapRequestToBroker(Create request)
        {
            return _mapper.Map<Create, CreateGroup>(request);
        }

        public DeleteGroup MapRequestToBroker(Delete request)
        {
            return _mapper.Map<Delete, DeleteGroup>(request);
        }

        public UpdateGroup MapRequestToBroker(Update request)
        {
            return _mapper.Map<Update, UpdateGroup>(request);
        }

        public GetGroup MapRequestToBroker(Get request)
        {
            return _mapper.Map<Get, GetGroup>(request);
        }

        public ListGroups MapRequestToBroker(List request)
        {
            return _mapper.Map<List, ListGroups>(request);
        }
    }
}