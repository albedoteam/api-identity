namespace Identity.Api.Services.UserTypeService.Requests
{
    using AlbedoTeam.Identity.Contracts.Common;
    using AlbedoTeam.Sdk.Cache.Attributes;
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    [Cache(120)]
    public class List : IRequest<Result<Paged<UserType>>>
    {
        public string AccountId { get; set; }
        public bool ShowDeleted { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string FilterBy { get; set; }
        public string OrderBy { get; set; }
        public Sorting Sorting { get; set; }
    }
}