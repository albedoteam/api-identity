using System.Threading.Tasks;
using AlbedoTeam.Identity.Contracts.Commands;
using AlbedoTeam.Sdk.FailFast;
using AlbedoTeam.Sdk.FailFast.Abstractions;
using AlbedoTeam.Sdk.MessageProducer.Services.Abstractions;
using Identity.Api.Mappers.Abstractions;
using Identity.Api.Models;
using Identity.Api.Services.UserService.Requests;

namespace Identity.Api.Services.UserService.Handlers
{
    public class ClearSessionsHandler : CommandHandler<ClearSessions, User>
    {
        private readonly IUserMapper _mapper;
        private readonly IProducerService _producer;

        public ClearSessionsHandler(IProducerService producer, IUserMapper mapper)
        {
            _producer = producer;
            _mapper = mapper;
        }

        protected override async Task<Result<User>> Handle(ClearSessions request)
        {
            await _producer.Send<ClearUserSessions>(_mapper.MapRequestToCommand(request));
            return new Result<User>();
        }
    }
}