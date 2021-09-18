﻿namespace Identity.Api.Controllers
{
    using System.Threading.Tasks;
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using NSwag.Annotations;
    using Services.AuthServerService.Requests;

    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [OpenApiTag("Authorization Servers", Description = "Albedo's authorization servers management")]
    public class AuthServerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthServerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Paged<AuthServer>>> List([FromQuery] List request)
        {
            var response = await _mediator.Send(request);

            return response.HasError
                ? HandleError(response)
                : Ok(response.Data);
        }

        [HttpGet("{id:regex(^[[0-9a-fA-F]]{{24}}$)}", Name = "GetAuthServer")]
        public async Task<ActionResult<AuthServer>> Get(
            string id,
            [FromQuery] string accountId,
            [FromQuery] bool showDeleted,
            [FromHeader(Name = CustomHeaders.NoCache)]
            bool noCache)
        {
            var response = await _mediator.Send(new Get
                {NoCache = noCache, AccountId = accountId, Id = id, ShowDeleted = showDeleted});
            return response.HasError
                ? HandleError(response)
                : Ok(response.Data);
        }

        [HttpPost]
        public async Task<ActionResult<AuthServer>> Post(Create request)
        {
            var response = await _mediator.Send(request);
            return response.HasError
                ? HandleError(response)
                : CreatedAtRoute(
                    "GetAuthServer",
                    new {accountId = response.Data.AccountId, id = response.Data.Id},
                    response.Data);
        }

        [HttpPut("{id:regex(^[[0-9a-fA-F]]{{24}}$)}")]
        public async Task<IActionResult> Put(string id, Update request)
        {
            if (id != request.Id)
                return BadRequest();

            var response = await _mediator.Send(request);
            return response.HasError
                ? HandleError(response)
                : NoContent();
        }

        [HttpDelete("{id:regex(^[[0-9a-fA-F]]{{24}}$)}")]
        public async Task<IActionResult> Delete([FromRoute] string id, [FromQuery] string accountId)
        {
            var response = await _mediator.Send(new Delete {AccountId = accountId, Id = id});
            return response.HasError
                ? HandleError(response)
                : NoContent();
        }

        [HttpPatch("{id:regex(^[[0-9a-fA-F]]{{24}}$)}/activate")]
        public async Task<IActionResult> Activate(string id, Activate request)
        {
            if (id != request.Id)
                return BadRequest();

            var response = await _mediator.Send(request);

            if (response.HasError)
                return BadRequest(response.Errors);

            return Accepted();
        }

        [HttpPatch("{id:regex(^[[0-9a-fA-F]]{{24}}$)}/deactivate")]
        public async Task<IActionResult> Deactivate(string id, Deactivate request)
        {
            if (id != request.Id)
                return BadRequest();

            var response = await _mediator.Send(request);

            if (response.HasError)
                return BadRequest(response.Errors);

            return Accepted();
        }

        private ActionResult HandleError<T>(Result<T> response)
        {
            ObjectResult DefaultError()
            {
                return Problem(string.Join(", ", response.Errors));
            }

            return response.FailureReason switch
            {
                FailureReason.Conflict => Conflict(response.Errors),
                FailureReason.BadRequest => BadRequest(response.Errors),
                FailureReason.NotFound => NotFound(response.Errors),
                FailureReason.InternalServerError => DefaultError(),
                null => DefaultError(),
                _ => DefaultError()
            };
        }
    }
}