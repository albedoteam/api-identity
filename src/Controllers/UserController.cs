namespace Identity.Api.Controllers
{
    using System.Threading.Tasks;
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using NSwag.Annotations;
    using Services.UserService.Requests;

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
        public async Task<ActionResult<Paged<User>>> List([FromQuery] List request)
        {
            var response = await _mediator.Send(request);

            return response.HasError
                ? HandleError(response)
                : Ok(response.Data);
        }

        [HttpGet("{id:regex(^[[0-9a-fA-F]]{{24}}$)}", Name = "GetUser")]
        public async Task<ActionResult<User>> Get(string id, [FromQuery] string accountId, [FromQuery] bool showDeleted)
        {
            var response = await _mediator.Send(new Get {Id = id, AccountId = accountId, ShowDeleted = showDeleted});
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
        public async Task<IActionResult> Delete(string id, [FromQuery] string accountId)
        {
            var response = await _mediator.Send(new Delete {Id = id, AccountId = accountId});
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

        [HttpPatch("{id:regex(^[[0-9a-fA-F]]{{24}}$)}/changePassword")]
        public async Task<IActionResult> ChangePassword(string id, ChangePassword request)
        {
            if (id != request.Id)
                return BadRequest();

            var response = await _mediator.Send(request);
            if (response.HasError)
                return BadRequest(response.Errors);

            return Accepted();
        }

        [HttpPatch("{id:regex(^[[0-9a-fA-F]]{{24}}$)}/setPassword")]
        public async Task<IActionResult> SetPassword(string id, SetPassword request)
        {
            if (id != request.Id)
                return BadRequest();

            var response = await _mediator.Send(request);
            if (response.HasError)
                return BadRequest(response.Errors);

            return Accepted();
        }

        [HttpPatch("{id:regex(^[[0-9a-fA-F]]{{24}}$)}/expirePassword")]
        public async Task<IActionResult> ExpirePassword(string id, ExpirePassword request)
        {
            if (id != request.Id)
                return BadRequest();

            var response = await _mediator.Send(request);
            if (response.HasError)
                return BadRequest(response.Errors);

            return Accepted();
        }

        [HttpPatch("{id:regex(^[[0-9a-fA-F]]{{24}}$)}/clearSessions")]
        public async Task<IActionResult> ClearSessions(string id, ClearSessions request)
        {
            if (id != request.Id)
                return BadRequest();

            var response = await _mediator.Send(request);
            if (response.HasError)
                return BadRequest(response.Errors);

            return Accepted();
        }

        [HttpPatch("{id:regex(^[[0-9a-fA-F]]{{24}}$)}/addGroup")]
        public async Task<IActionResult> AddGroup(string id, AddGroup request)
        {
            if (id != request.UserId)
                return BadRequest();

            var response = await _mediator.Send(request);
            if (response.HasError)
                return BadRequest(response.Errors);

            return Accepted();
        }

        [HttpPatch("{id:regex(^[[0-9a-fA-F]]{{24}}$)}/removeGroup")]
        public async Task<IActionResult> RemoveGroup(string id, RemoveGroup request)
        {
            if (id != request.UserId)
                return BadRequest();

            var response = await _mediator.Send(request);
            if (response.HasError)
                return BadRequest(response.Errors);

            return Accepted();
        }

        [HttpPatch("{id:regex(^[[0-9a-fA-F]]{{24}}$)}/changeUserType")]
        public async Task<IActionResult> ChangeUserType(string id, ChangeUserType request)
        {
            if (id != request.UserId)
                return BadRequest();

            var response = await _mediator.Send(request);
            if (response.HasError)
                return BadRequest(response.Errors);

            return Accepted();
        }

        [HttpPatch("{id:regex(^[[0-9a-fA-F]]{{24}}$)}/resendInvite")]
        public async Task<IActionResult> ResendInvite(string id, ResendInvite request)
        {
            if (id != request.UserId)
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