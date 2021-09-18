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

    public class DeactivateHandler : CommandHandler<Deactivate, User>
    {
        private readonly IUserMapper _mapper;
        private readonly IProducerService _producer;

        public DeactivateHandler(IProducerService producer, IUserMapper mapper)
        {
            _producer = producer;
            _mapper = mapper;
        }

        protected override async Task<Result<User>> Handle(Deactivate request)
        {
            await _producer.Send<DeactivateUser>(_mapper.MapRequestToCommand(request));
            return new Result<User>();
        }
    }
}