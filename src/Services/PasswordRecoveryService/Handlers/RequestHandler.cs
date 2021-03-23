using System.Threading.Tasks;
using AlbedoTeam.Identity.Contracts.Commands;
using AlbedoTeam.Sdk.FailFast;
using AlbedoTeam.Sdk.FailFast.Abstractions;
using AlbedoTeam.Sdk.MessageProducer.Services.Abstractions;
using Identity.Api.Mappers.Abstractions;
using Identity.Api.Models;
using Identity.Api.Services.PasswordRecoveryService.Requests;

namespace Identity.Api.Services.PasswordRecoveryService.Handlers
{
    public class RequestHandler: CommandHandler<Request, PasswordRecovery>
    {
        private readonly IPasswordRecoveryMapper _mapper;
        private readonly IProducerService _producer;

        public RequestHandler(IPasswordRecoveryMapper mapper, IProducerService producer)
        {
            _mapper = mapper;
            _producer = producer;
        }

        protected override async Task<Result<PasswordRecovery>> Handle(Request request)
        {
            await _producer.Send<RequestPasswordChange>(_mapper.MapRequestToCommand(request));
            return new Result<PasswordRecovery>();
        }
    }
}