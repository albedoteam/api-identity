﻿namespace Identity.Api.Mappers
{
    using System.Collections.Generic;
    using Abstractions;
    using AlbedoTeam.Identity.Contracts.Commands;
    using AlbedoTeam.Identity.Contracts.Common;
    using AlbedoTeam.Identity.Contracts.Requests;
    using AlbedoTeam.Identity.Contracts.Responses;
    using AutoMapper;
    using Models;
    using Services.AuthServerService.Requests;

    public class AuthServerMapper : IAuthServerMapper
    {
        private readonly IMapper _mapper;

        public AuthServerMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Broker Responses to Model
                cfg.CreateMap<AuthServer, AuthServerResponse>().ReverseMap();
                cfg.CreateMap<CommunicationRules, ICommunicationRules>().ReverseMap();
                cfg.CreateMap<CommunicationRule, ICommunicationRule>().ReverseMap();

                // MediatR to Broker Requests
                cfg.CreateMap<Create, CreateAuthServer>().ReverseMap();
                cfg.CreateMap<Delete, DeleteAuthServer>().ReverseMap();
                cfg.CreateMap<Update, UpdateAuthServer>().ReverseMap();
                cfg.CreateMap<Get, GetAuthServer>().ReverseMap();
                cfg.CreateMap<List, ListAuthServers>().ReverseMap();

                // MediatR to Broker Commands
                cfg.CreateMap<Activate, ActivateAuthServer>().ReverseMap();
                cfg.CreateMap<Deactivate, DeactivateAuthServer>().ReverseMap();
            });

            _mapper = config.CreateMapper();
        }

        public AuthServer MapResponseToModel(AuthServerResponse response)
        {
            return _mapper.Map<AuthServerResponse, AuthServer>(response);
        }

        public List<AuthServer> MapResponseToModel(List<AuthServerResponse> response)
        {
            return _mapper.Map<List<AuthServerResponse>, List<AuthServer>>(response);
        }

        public CreateAuthServer MapRequestToBroker(Create request)
        {
            return _mapper.Map<Create, CreateAuthServer>(request);
        }

        public DeleteAuthServer MapRequestToBroker(Delete request)
        {
            return _mapper.Map<Delete, DeleteAuthServer>(request);
        }

        public GetAuthServer MapRequestToBroker(Get request)
        {
            return _mapper.Map<Get, GetAuthServer>(request);
        }

        public ListAuthServers MapRequestToBroker(List request)
        {
            return _mapper.Map<List, ListAuthServers>(request);
        }

        public UpdateAuthServer MapRequestToBroker(Update request)
        {
            return _mapper.Map<Update, UpdateAuthServer>(request);
        }

        public ActivateAuthServer MapRequestToCommand(Activate request)
        {
            return _mapper.Map<Activate, ActivateAuthServer>(request);
        }

        public DeactivateAuthServer MapRequestToCommand(Deactivate request)
        {
            return _mapper.Map<Deactivate, DeactivateAuthServer>(request);
        }
    }
}