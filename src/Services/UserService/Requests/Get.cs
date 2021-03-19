using AlbedoTeam.Sdk.FailFast;
using Identity.Api.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Services.UserService.Requests
{
    public class Get : IRequest<Result<User>>
    {
        public string Id { get; set; }
        public string AccountId { get; set; }
        public bool ShowDeleted { get; set; }
    }
}