using System.Threading.Tasks;
using AlbedoTeam.Identity.Contracts.Requests;
using AlbedoTeam.Identity.Contracts.Responses;
using AlbedoTeam.Sdk.FailFast;
using AlbedoTeam.Sdk.FailFast.Abstractions;
using Identity.Api.Extensions;
using Identity.Api.Mappers.Abstractions;
using Identity.Api.Models;
using Identity.Api.Services.PasswordRecoveryService.Requests;
using MassTransit;

namespace Identity.Api.Services.PasswordRecoveryService.Handlers
{
    public class GetHandler: QueryHandler<Get, PasswordRecovery>
    {
        private readonly IRequestClient<GetPasswordRecovery> _client;
        private readonly IPasswordRecoveryMapper _mapper;

        public GetHandler(IRequestClient<GetPasswordRecovery> client, IPasswordRecoveryMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        protected override async Task<Result<PasswordRecovery>> Handle(Get request)
        {
            var (successResponse, errorResponse) =
                await _client.GetResponse<PasswordRecoveryResponse, ErrorResponse>(_mapper.MapRequestToBroker(request));

            if (errorResponse.IsCompletedSuccessfully)
                return await errorResponse.Parse<PasswordRecovery>();

            var passwordRecovery = (await successResponse).Message;
            return new Result<PasswordRecovery>(_mapper.MapResponseToModel(passwordRecovery));
        }
    }
}