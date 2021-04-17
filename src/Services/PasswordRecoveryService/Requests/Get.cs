namespace Identity.Api.Services.PasswordRecoveryService.Requests
{
    using AlbedoTeam.Sdk.Cache.Attributes;
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    [Cache(120)]
    public class Get : IRequest<Result<PasswordRecovery>>
    {
        public string AccountId { get; set; }
        public string ValidationToken { get; set; }
    }
}