namespace Identity.Api.Controllers
{
    using System.Threading.Tasks;
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using NSwag.Annotations;
    using Services.UserTypeService.Requests;

    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [OpenApiTag("User Types", Description = "Albedo's user types management")]
    public class UserTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Paged<UserType>>> List([FromQuery] List request)
        {
            var response = await _mediator.Send(request);
            return response.HasError
                ? HandleError(response)
                : Ok(response.Data);
        }

        [HttpGet("{id:regex(^[[0-9a-fA-F]]{{24}}$)}", Name = "GetUserType")]
        public async Task<ActionResult<UserType>> Get(
            string id,
            [FromQuery] string accountId,
            [FromQuery] bool showDeleted,
            [FromHeader(Name = CustomHeaders.NoCache)]
            bool noCache)
        {
            var response = await _mediator.Send(new Get
                {NoCache = noCache, Id = id, AccountId = accountId, ShowDeleted = showDeleted});
            return response.HasError
                ? HandleError(response)
                : Ok(response.Data);
        }

        [HttpPost]
        public async Task<ActionResult<UserType>> Post(Create request)
        {
            var response = await _mediator.Send(request);
            return response.HasError
                ? HandleError(response)
                : CreatedAtRoute("GetUserType", new {id = response.Data.Id}, response.Data);
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

        [HttpPatch("{id:regex(^[[0-9a-fA-F]]{{24}}$)}/addGroup")]
        public async Task<IActionResult> AddGroup(string id, AddGroup request)
        {
            if (id != request.UserTypeId)
                return BadRequest();

            var response = await _mediator.Send(request);

            if (response.HasError)
                return BadRequest(response.Errors);

            return Accepted();
        }

        [HttpPatch("{id:regex(^[[0-9a-fA-F]]{{24}}$)}/removeGroup")]
        public async Task<IActionResult> RemoveGroup(string id, RemoveGroup request)
        {
            if (id != request.UserTypeId)
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