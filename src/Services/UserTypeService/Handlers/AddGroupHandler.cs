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
    public class AddGroupHandler : CommandHandler<AddGroup, UserType>
    {
        private readonly IUserTypeMapper _mapper;
        private readonly IProducerService _producer;

        public AddGroupHandler(IProducerService producer, IUserTypeMapper mapper)
        {
            _producer = producer;
            _mapper = mapper;
        }

        protected override async Task<Result<UserType>> Handle(AddGroup request)
        {
            await _producer.Send<AddGroupToUserType>(_mapper.MapRequestToCommand(request));
            return new Result<UserType>();
        }
    }
}