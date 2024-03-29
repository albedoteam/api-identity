﻿namespace Identity.Api.Services.AuthServerService.Handlers
{
    using System.Threading.Tasks;
    using AlbedoTeam.Identity.Contracts.Commands;
    using AlbedoTeam.Sdk.FailFast;
    using AlbedoTeam.Sdk.FailFast.Abstractions;
    using AlbedoTeam.Sdk.MessageProducer.Services.Abstractions;
    using Mappers.Abstractions;
    using Models;
    using Requests;

    public class DeactivateHandler : CommandHandler<Deactivate, AuthServer>
    {
        private readonly IAuthServerMapper _mapper;
        private readonly IProducerService _producer;

        public DeactivateHandler(IProducerService producer, IAuthServerMapper mapper)
        {
            _producer = producer;
            _mapper = mapper;
        }

        protected override async Task<Result<AuthServer>> Handle(Deactivate request)
        {
            await _producer.Send<DeactivateAuthServer>(_mapper.MapRequestToCommand(request));
            return new Result<AuthServer>();
        }
    }
}