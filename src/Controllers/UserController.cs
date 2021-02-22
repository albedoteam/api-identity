using System.Threading.Tasks;
using AlbedoTeam.Identity.Contracts.Common;
using AlbedoTeam.Sdk.FailFast;
using Identity.Api.Models;
using Identity.Api.Services.UserService.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Identity.Api.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [OpenApiTag("Users", Description = "Albedo's users management")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Paged<User>>> List(
            [FromQuery] bool showDeleted,
            [FromQuery] int? page,
            [FromQuery] int? pageSize,
            [FromQuery] string filterBy,
            [FromQuery] string orderBy,
            [FromQuery] Sorting sortBy)
        {
            var response = await _mediator.Send(new List
            {
                ShowDeleted = showDeleted,
                Page = page ?? 1,
                PageSize = pageSize ?? 1,
                FilterBy = filterBy,
                OrderBy = orderBy,
                Sorting = sortBy
            });

            return response.HasError
                ? HandleError(response)
                : Ok(response.Data);
        }

        [HttpGet("{id:regex(^[[0-9a-fA-F]]{{24}}$)}", Name = "GetUser")]
        public async Task<ActionResult<User>> Get(string id, [FromQuery] bool showDeleted)
        {
            var response = await _mediator.Send(new Get {Id = id, ShowDeleted = showDeleted});
            return response.HasError
                ? HandleError(response)
                : Ok(response.Data);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(Create request)
        {
            var response = await _mediator.Send(request);
            return response.HasError
                ? HandleError(response)
                : CreatedAtRoute("GetUser", new {id = response.Data.Id}, response.Data);
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
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _mediator.Send(new Delete {Id = id});
            return response.HasError
                ? HandleError(response)
                : NoContent();
        }

        [HttpPatch("activate")]
        public async Task<IActionResult> Activate(Activate request)
        {
            var response = await _mediator.Send(request);
            if (response.HasError)
                return BadRequest(response.Errors);

            return Accepted();
        }

        [HttpPatch("deactivate")]
        public async Task<IActionResult> Deactivate(Deactivate request)
        {
            var response = await _mediator.Send(request);
            if (response.HasError)
                return BadRequest(response.Errors);

            return Accepted();
        }

        [HttpPatch("changePassword")]
        public async Task<IActionResult> ChangePassword(ChangePassword request)
        {
            var response = await _mediator.Send(request);
            if (response.HasError)
                return BadRequest(response.Errors);

            return Accepted();
        }

        [HttpPatch("setPassword")]
        public async Task<IActionResult> SetPassword(SetPassword request)
        {
            var response = await _mediator.Send(request);
            if (response.HasError)
                return BadRequest(response.Errors);

            return Accepted();
        }

        [HttpPatch("expirePassword")]
        public async Task<IActionResult> ExpirePassword(ExpirePassword request)
        {
            var response = await _mediator.Send(request);
            if (response.HasError)
                return BadRequest(response.Errors);

            return Accepted();
        }

        [HttpPatch("clearSessions")]
        public async Task<IActionResult> ClearSessions(ClearSessions request)
        {
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