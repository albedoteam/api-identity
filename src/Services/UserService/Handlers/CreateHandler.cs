namespace Identity.Api.Services.UserService.Handlers
{
    using System.Threading.Tasks;
    using AlbedoTeam.Identity.Contracts.Requests;
    using AlbedoTeam.Identity.Contracts.Responses;
    using AlbedoTeam.Sdk.FailFast;
    using AlbedoTeam.Sdk.FailFast.Abstractions;
    using Extensions;
    using Mappers.Abstractions;
    using MassTransit;
    using Models;
    using Requests;

    public class CreateHandler : CommandHandler<Create, User>
    {
        private readonly IRequestClient<CreateUser> _client;
        private readonly IUserMapper _mapper;

        public CreateHandler(IRequestClient<CreateUser> client, IUserMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        protected override async Task<Result<User>> Handle(Create request)
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