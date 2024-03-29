﻿namespace Identity.Api.Services.AuthServerService.Requests
{
    using AlbedoTeam.Identity.Contracts.Common;
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    // [Cache(7200)]
    public class List : IRequest<Result<Paged<AuthServer>>>
    {
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