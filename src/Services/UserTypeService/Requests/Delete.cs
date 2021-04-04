namespace Identity.Api.Services.UserTypeService.Requests
{
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    public class Delete : IRequest<Result<UserType>>
    {
        public string AccountId { get; set; }
        public string Id { get; set; }
    }
}