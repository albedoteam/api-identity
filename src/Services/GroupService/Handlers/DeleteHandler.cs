using System.Threading.Tasks;
using AlbedoTeam.Identity.Contracts.Requests;
using AlbedoTeam.Identity.Contracts.Responses;
using AlbedoTeam.Sdk.FailFast;
using AlbedoTeam.Sdk.FailFast.Abstractions;
using Identity.Api.Extensions;
using Identity.Api.Mappers.Abstractions;
using Identity.Api.Models;
using Identity.Api.Services.GroupService.Requests;
using MassTransit;

namespace Identity.Api.Services.GroupService.Handlers
{
    public class DeleteHandler : CommandHandler<Delete, Group>
    {
        private readonly IRequestClient<DeleteGroup> _client;
        private readonly IGroupMapper _mapper;

        public DeleteHandler(IRequestClient<DeleteGroup> client, IGroupMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        protected override async Task<Result<Group>> Handle(Delete request)
        {
            var (successResponse, errorResponse) =
                await _client.GetResponse<GroupResponse, ErrorResponse>(_mapper.MapRequestToBroker(request));

            if (errorResponse.IsCompletedSuccessfully)
                return await errorResponse.Parse<Group>();

            var group = (await successResponse).Message;
            return new Result<Group>(_mapper.MapResponseToModel(group));
        }
    }
}