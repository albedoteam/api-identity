using AlbedoTeam.Identity.Contracts.Commands;
using AlbedoTeam.Identity.Contracts.Requests;
using AlbedoTeam.Identity.Contracts.Responses;
using AutoMapper;
using Identity.Api.Mappers.Abstractions;
using Identity.Api.Models;
using Identity.Api.Services.PasswordRecoveryService.Requests;

namespace Identity.Api.Mappers
{
    public class PasswordRecoveryMapper: IPasswordRecoveryMapper
    {
        private readonly IMapper _mapper;

        public PasswordRecoveryMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // Broker Responses to Model
                cfg.CreateMap<PasswordRecovery, PasswordRecoveryResponse>().ReverseMap();

                // MediatR to Broker Requests
                cfg.CreateMap<Get, GetPasswordRecovery>().ReverseMap();

                // MediatR to Broker Commands
                cfg.CreateMap<Request, RequestPasswordChange>().ReverseMap();
            });

            _mapper = config.CreateMapper();
        }
        
        public PasswordRecovery MapResponseToModel(PasswordRecoveryResponse response)
        {
            return _mapper.Map<PasswordRecoveryResponse, PasswordRecovery>(response);
        }

        public GetPasswordRecovery MapRequestToBroker(Get request)
        {
            return _mapper.Map<Get, GetPasswordRecovery>(request);
        }

        public RequestPasswordChange MapRequestToCommand(Request request)
        {
            return _mapper.Map<Request, RequestPasswordChange>(request);
        }
    }
}