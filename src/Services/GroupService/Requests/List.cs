﻿using AlbedoTeam.Identity.Contracts.Common;
using AlbedoTeam.Sdk.FailFast;
using Identity.Api.Models;
using MediatR;

namespace Identity.Api.Services.GroupService.Requests
{
    public class List : IRequest<Result<Paged<Group>>>
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