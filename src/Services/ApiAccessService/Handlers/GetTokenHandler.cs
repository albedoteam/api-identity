namespace Identity.Api.Services.ApiAccessService.Handlers
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using AlbedoTeam.Sdk.FailFast;
    using AlbedoTeam.Sdk.FailFast.Abstractions;
    using AuthServerService.Requests;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using Models;
    using Requests;

    public class GetTokenHandler : QueryHandler<GetToken, Authentication>
    {
        private readonly ILogger<GetTokenHandler> _logger;
        private readonly IMediator _mediator;

        public GetTokenHandler(ILogger<GetTokenHandler> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        protected override async Task<Result<Authentication>> Handle(GetToken request)
        {
            var authServer = await RequestAuthServer(request.AccountId);
            if (authServer is null)
                return new Result<Authentication>(FailureReason.Conflict, "Invalid authentication");

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Basic {request.Secret}");

            var form = new Dictionary<string, string>
            {
                {"grant_type", "client_credentials"}, {"scope", "customScope"}
            };

            var req = new HttpRequestMessage(HttpMethod.Post, authServer.AccessTokenUrl)
            {
                Content = new FormUrlEncodedContent(form)
            };

            var responseMessage = await client.SendAsync(req);

            if (!responseMessage.IsSuccessStatusCode)
            {
                var responseErrorMessage = $"{responseMessage.StatusCode}-{responseMessage.ReasonPhrase}";
                _logger.LogInformation("Invalid authentication: {Error}", responseErrorMessage);
                return new Result<Authentication>(FailureReason.Conflict, "Invalid authentication");
            }

            await using var responseStream = await responseMessage.Content.ReadAsStreamAsync();
            var authResponse = await JsonSerializer.DeserializeAsync<Authentication>(responseStream,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            return new Result<Authentication>(authResponse);
        }

        private async Task<AuthServer> RequestAuthServer(string accountId)
        {
            var authServerResponse = await _mediator.Send(new List
            {
                Page = 1,
                PageSize = 1,
                FilterBy = $"accountId eq '{accountId}'",
                ShowDeleted = false
            });

            if (authServerResponse.HasError)
            {
                _logger.LogInformation("Invalid authentication: {Error}", string.Join(", ", authServerResponse.Errors));
                return null;
            }

            if (authServerResponse.Data.RecordsInPage != 1)
            {
                const string invalidAuthServerCfg = "Auth server has more than 1 configuration";
                _logger.LogInformation("Invalid authentication: {Error}", invalidAuthServerCfg);
                return null;
            }

            var authServer = authServerResponse.Data.Items[0];
            return authServer;
        }
    }
}