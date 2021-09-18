namespace Identity.Api.Services.GroupService.Requests
{
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    public class Delete : IRequest<Result<Group>>
    {
        public string AccountId { get; set; }
        public string Id { get; set; }
    }
}