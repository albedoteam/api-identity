namespace Identity.Api.Services.PasswordRecoveryService.Handlers
{
    using System.Threading.Tasks;
    using AlbedoTeam.Identity.Contracts.Commands;
    using AlbedoTeam.Sdk.FailFast;
    using AlbedoTeam.Sdk.FailFast.Abstractions;
    using AlbedoTeam.Sdk.MessageProducer.Services.Abstractions;
    using Mappers.Abstractions;
    using Models;
    using Requests;

    public class CreateHandler : CommandHandler<Create, PasswordRecovery>
    {
        private readonly IPasswordRecoveryMapper _mapper;
        private readonly IProducerService _producer;

        public CreateHandler(IPasswordRecoveryMapper mapper, IProducerService producer)
        {
            _mapper = mapper;
            _producer = producer;
        }

        protected override async Task<Result<PasswordRecovery>> Handle(Create create)
        {
            await _producer.Send<CreatePasswordRecovery>(_mapper.MapRequestToCommand(create));
            return new Result<PasswordRecovery>();
        }
    }
}