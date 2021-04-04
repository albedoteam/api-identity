namespace Identity.Api.Services.UserTypeService.Requests
{
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    public class Update : IRequest<Result<UserType>>
    {
        public string AccountId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
    }
}