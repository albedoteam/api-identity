using System.Threading.Tasks;
using AlbedoTeam.Identity.Contracts.Commands;
using AlbedoTeam.Sdk.FailFast;
using AlbedoTeam.Sdk.FailFast.Abstractions;
using AlbedoTeam.Sdk.MessageProducer.Services.Abstractions;
using Identity.Api.Mappers.Abstractions;
using Identity.Api.Models;
using Identity.Api.Services.UserTypeService.Requests;

namespace Identity.Api.Services.UserTypeService.Handlers
{
    public class RemoveGroupHandler : CommandHandler<RemoveGroup, UserType>
    {
        private readonly IUserTypeMapper _mapper;
        private readonly IProducerService _producer;

        public RemoveGroupHandler(IProducerService producer, IUserTypeMapper mapper)
        {
            _producer = producer;
            _mapper = mapper;
        }

        protected override async Task<Result<UserType>> Handle(RemoveGroup request)
        {
            await _producer.Send<RemoveGroupFromUserType>(_mapper.MapRequestToCommand(request));
            return new Result<UserType>();
        }
    }
}