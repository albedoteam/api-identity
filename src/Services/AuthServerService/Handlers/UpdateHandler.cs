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

    public class UpdateHandler : CommandHandler<Update, AuthServer>
    {
        private readonly IRequestClient<UpdateAuthServer> _client;
        private readonly IAuthServerMapper _mapper;

        public UpdateHandler(IRequestClient<UpdateAuthServer> client, IAuthServerMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        protected override async Task<Result<AuthServer>> Handle(Update request)
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