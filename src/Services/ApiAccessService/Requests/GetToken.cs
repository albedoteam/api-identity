namespace Identity.Api.Services.ApiAccessService.Requests
{
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    public class GetToken : IRequest<Result<Authentication>>
    {
        public string AccountId { get; set; }
        public string Secret { get; set; }
    }
}