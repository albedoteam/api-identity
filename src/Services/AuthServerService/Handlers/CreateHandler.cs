namespace Identity.Api.Services.AuthServerService.Handlers
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

    public class CreateHandler : CommandHandler<Create, AuthServer>
    {
        private readonly IRequestClient<CreateAuthServer> _client;
        private readonly IAuthServerMapper _mapper;

        public CreateHandler(IRequestClient<CreateAuthServer> client, IAuthServerMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        protected override async Task<Result<AuthServer>> Handle(Create request)
        {
            var (successResponse, errorResponse) =
                await _client.GetResponse<AuthServerResponse, ErrorResponse>(_mapper.MapRequestToBroker(request));

            if (errorResponse.IsCompletedSuccessfully)
                return await errorResponse.Parse<AuthServer>();

            var authServer = (await successResponse).Message;
            return new Result<AuthServer>(_mapper.MapResponseToModel(authServer));
        }
    }
}