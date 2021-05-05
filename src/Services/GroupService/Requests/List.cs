namespace Identity.Api.Services.GroupService.Requests
{
    using AlbedoTeam.Identity.Contracts.Common;
    using AlbedoTeam.Sdk.Cache.Attributes;
    using AlbedoTeam.Sdk.FailFast;
    using AlbedoTeam.Sdk.FailFast.Abstractions;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    // [Cache(120)]
    public class List : IRequest<Result<Paged<Group>>>
    {
        [FromQuery]
        public string AccountId { get; set; }

        [FromQuery]
        public bool ShowDeleted { get; set; }

        [FromQuery]
        public int Page { get; set; }

        [FromQuery]
        public int PageSize { get; set; }

        [FromQuery]
        public string FilterBy { get; set; }

        [FromQuery]
        public string OrderBy { get; set; }

        [FromQuery]
        public Sorting Sorting { get; set; }

        [FromHeader(Name = CustomHeaders.NoCache)]
        public bool NoCache { get; set; }
    }
}