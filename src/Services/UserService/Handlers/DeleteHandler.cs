using System.Threading.Tasks;
using AlbedoTeam.Identity.Contracts.Requests;
using AlbedoTeam.Identity.Contracts.Responses;
using AlbedoTeam.Sdk.FailFast;
using AlbedoTeam.Sdk.FailFast.Abstractions;
using Identity.Api.Extensions;
using Identity.Api.Mappers.Abstractions;
using Identity.Api.Models;
using Identity.Api.Services.UserService.Requests;
using MassTransit;

namespace Identity.Api.Services.UserService.Handlers
{
    public class DeleteHandler : CommandHandler<Delete, User>
    {
        private readonly IRequestClient<DeleteUser> _client;
        private readonly IUserMapper _mapper;

        public DeleteHandler(IRequestClient<DeleteUser> client, IUserMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        protected override async Task<Result<User>> Handle(Delete request)
        {
            var (successResponse, errorResponse) =
                await _client.GetResponse<UserResponse, ErrorResponse>(_mapper.MapRequestToBroker(request));

            if (errorResponse.IsCompletedSuccessfully)
                return await errorResponse.Parse<User>();

            var user = (await successResponse).Message;
            return new Result<User>(_mapper.MapResponseToModel(user));
        }
    }
}