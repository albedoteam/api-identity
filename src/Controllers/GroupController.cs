namespace Identity.Api.Controllers
{
    using System.Threading.Tasks;
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using NSwag.Annotations;
    using Services.GroupService.Requests;

    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [OpenApiTag("Groups", Description = "Albedo's groups management")]
    public class GroupController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Paged<Group>>> List([FromQuery] List request)
        {
            var response = await _mediator.Send(request);

            return response.HasError
                ? HandleError(response)
                : Ok(response.Data);
        }

        [HttpGet("{id:regex(^[[0-9a-fA-F]]{{24}}$)}", Name = "GetGroup")]
        public async Task<ActionResult<Group>> Get(
            string id,
            [FromQuery] string accountId,
            [FromQuery] bool showDeleted)
        {
            var response = await _mediator.Send(new Get {Id = id, AccountId = accountId, ShowDeleted = showDeleted});
            return response.HasError
                ? HandleError(response)
                : Ok(response.Data);
        }

        [HttpPost]
        public async Task<ActionResult<Group>> Post(Create request)
        {
            var response = await _mediator.Send(request);
            return response.HasError
                ? HandleError(response)
                : CreatedAtRoute("GetGroup", new {id = response.Data.Id}, response.Data);
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