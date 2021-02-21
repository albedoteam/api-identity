using System.Threading.Tasks;
using AlbedoTeam.Identity.Contracts.Requests;
using AlbedoTeam.Identity.Contracts.Responses;
using AlbedoTeam.Sdk.FailFast;
using AlbedoTeam.Sdk.FailFast.Abstractions;
using Identity.Api.Extensions;
using Identity.Api.Mappers.Abstractions;
using Identity.Api.Models;
using Identity.Api.Services.AuthServerService.Requests;
using MassTransit;

namespace Identity.Api.Services.AuthServerService.Handlers
{
    public class GetHandler : QueryHandler<Get, AuthServer>
    {
        private readonly IRequestClient<GetAuthServer> _client;
        private readonly IAuthServerMapper _mapper;

        public GetHandler(IRequestClient<GetAuthServer> client, IAuthServerMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        protected override async Task<Result<AuthServer>> Handle(Get request)
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