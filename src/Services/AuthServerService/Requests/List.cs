namespace Identity.Api.Services.AuthServerService.Requests
{
    using AlbedoTeam.Identity.Contracts.Common;
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    public class List : IRequest<Result<Paged<AuthServer>>>
    {
        public bool ShowDeleted { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string FilterBy { get; set; }
        public string OrderBy { get; set; }
        public Sorting Sorting { get; set; }
    }
}