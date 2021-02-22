using System.Threading.Tasks;
using AlbedoTeam.Identity.Contracts.Common;
using AlbedoTeam.Sdk.FailFast;
using Identity.Api.Models;
using Identity.Api.Services.GroupService.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Identity.Api.Controllers
{
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
        public async Task<ActionResult<Paged<Group>>> List(
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

        [HttpGet("{id:regex(^[[0-9a-fA-F]]{{24}}$)}", Name = "GetGroup")]
        public async Task<ActionResult<Group>> Get(string id, [FromQuery] bool showDeleted)
        {
            var response = await _mediator.Send(new Get {Id = id, ShowDeleted = showDeleted});
            return response.HasError
                ? HandleError(response)
                : Ok(response.Data);
        }

        [HttpPost]
        // [ProducesResponseType(typeof(Group), StatusCodes.Status201Created)]
        // [ProducesResponseType(typeof(IEnumerable<AlbedoError>), StatusCodes.Status400BadRequest)]
        // [ProducesResponseType(StatusCodes.Status404NotFound)]
        // [ProducesResponseType(StatusCodes.Status409Conflict)]
        // [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _mediator.Send(new Delete {Id = id});
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

    // public enum AlbedoErrorCode
    // {
    //     PA001,
    //     PA002,
    //     PA003
    // }
    //
    // public struct AlbedoError
    // {
    //     public AlbedoErrorCode Code { get; set; }
    //     public string Message { get; set; }
    // }
}