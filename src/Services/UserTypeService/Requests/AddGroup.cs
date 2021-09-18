namespace Identity.Api.Services.UserTypeService.Requests
{
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    public class AddGroup : IRequest<Result<UserType>>
    {
        public string AccountId { get; set; }
        public string UserTypeId { get; set; }
        public string GroupId { get; set; }
    }
}