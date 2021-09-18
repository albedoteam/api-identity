namespace Identity.Api.Services.UserService.Handlers
{
    using System.Threading.Tasks;
    using AlbedoTeam.Identity.Contracts.Commands;
    using AlbedoTeam.Sdk.FailFast;
    using AlbedoTeam.Sdk.FailFast.Abstractions;
    using AlbedoTeam.Sdk.MessageProducer.Services.Abstractions;
    using Mappers.Abstractions;
    using Models;
    using Requests;

    public class ResendInviteHandler : CommandHandler<ResendInvite, User>
    {
        private readonly IUserMapper _mapper;
        private readonly IProducerService _producer;

        public ResendInviteHandler(IUserMapper mapper, IProducerService producer)
        {
            _mapper = mapper;
            _producer = producer;
        }

        protected override async Task<Result<User>> Handle(ResendInvite request)
        {
            await _producer.Send<ResendFirstAccessEmail>(_mapper.MapRequestToCommand(request));
            return new Result<User>();
        }
    }
}