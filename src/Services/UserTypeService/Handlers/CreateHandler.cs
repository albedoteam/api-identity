using System.Threading.Tasks;
using AlbedoTeam.Identity.Contracts.Requests;
using AlbedoTeam.Identity.Contracts.Responses;
using AlbedoTeam.Sdk.FailFast;
using AlbedoTeam.Sdk.FailFast.Abstractions;
using Identity.Api.Extensions;
using Identity.Api.Mappers.Abstractions;
using Identity.Api.Models;
using Identity.Api.Services.UserTypeService.Requests;
using MassTransit;

namespace Identity.Api.Services.UserTypeService.Handlers
{
    public class CreateHandler : CommandHandler<Create, UserType>
    {
        private readonly IRequestClient<CreateUserType> _client;
        private readonly IUserTypeMapper _mapper;

        public CreateHandler(IRequestClient<CreateUserType> client, IUserTypeMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        protected override async Task<Result<UserType>> Handle(Create request)
        {
            var (successResponse, errorResponse) =
                await _client.GetResponse<UserTypeResponse, ErrorResponse>(_mapper.MapRequestToBroker(request));

            if (errorResponse.IsCompletedSuccessfully)
                return await errorResponse.Parse<UserType>();

            var userType = (await successResponse).Message;
            return new Result<UserType>(_mapper.MapResponseToModel(userType));
        }
    }
}