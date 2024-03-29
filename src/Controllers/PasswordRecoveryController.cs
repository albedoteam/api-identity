﻿namespace Identity.Api.Controllers
{
    using System.Threading.Tasks;
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using NSwag.Annotations;
    using Services.PasswordRecoveryService.Requests;

    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [OpenApiTag("Password Recovery", Description = "Albedo's password recovery management")]
    public class PasswordRecoveryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PasswordRecoveryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<PasswordRecovery>> Get([FromQuery] Get request)
        {
            var response = await _mediator.Send(request);
            return response.HasError
                ? HandleError(response)
                : Ok(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Create create)
        {
            var response = await _mediator.Send(create);
            return response.HasError
                ? HandleError(response)
                : NoContent();
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