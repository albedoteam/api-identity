namespace Identity.Api.Services.PasswordRecoveryService.Requests
{
    using AlbedoTeam.Sdk.Cache.Attributes;
    using AlbedoTeam.Sdk.FailFast;
    using AlbedoTeam.Sdk.FailFast.Abstractions;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    // [Cache(120)]
    public class Get : IRequest<Result<PasswordRecovery>>
    {
        [FromQuery]
        public string AccountId { get; set; }

        [FromQuery]
        public string ValidationToken { get; set; }

        [FromHeader(Name = CustomHeaders.NoCache)]
        public bool NoCache { get; set; }
    }
}