namespace Identity.Api.Controllers
{
    using System.Threading.Tasks;
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using NSwag.Annotations;
    using Services.ApiAccessService.Requests;

    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [OpenApiTag("API Access", Description = "Albedo's api access management")]
    public class ApiAccessController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApiAccessController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("token")]
        public async Task<ActionResult<Authentication>> GetToken(
            [FromQuery] string accountId,
            [FromQuery] string secret)
        {
            var response = await _mediator.Send(new GetToken
            {
                AccountId = accountId,
                Secret = secret
            });

            return response.HasError
                ? HandleError(response)
                : Ok(response.Data);
        }

        private ActionResult HandleError<T>(Result<T> response)
        {
            ObjectResult DefaultError()
            {
                return Problem(string.Join(", ", response.Errors));
            }

            return response.FailureReason switch
            {
                FailureReason.Conflict => Unauthorized(),
                FailureReason.BadRequest => BadRequest(response.Errors),
                FailureReason.NotFound => NotFound(response.Errors),
                FailureReason.InternalServerError => DefaultError(),
                null => Unauthorized(),
                _ => Unauthorized()
            };
        }
    }
}