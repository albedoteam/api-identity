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

    public class ChangeUserTypeHandler : CommandHandler<ChangeUserType, User>
    {
        private readonly IUserMapper _mapper;
        private readonly IProducerService _producer;

        public ChangeUserTypeHandler(IProducerService producer, IUserMapper mapper)
        {
            _producer = producer;
            _mapper = mapper;
        }

        protected override async Task<Result<User>> Handle(ChangeUserType request)
        {
            await _producer.Send<ChangeUserTypeOnUser>(_mapper.MapRequestToCommand(request));
            return new Result<User>();
        }
    }
}