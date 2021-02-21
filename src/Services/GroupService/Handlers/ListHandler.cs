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
    public class ListHandler : QueryHandler<List, Paged<Group>>
    {
        private readonly IRequestClient<ListGroups> _client;
        private readonly IGroupMapper _mapper;

        public ListHandler(IRequestClient<ListGroups> client, IGroupMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        protected override async Task<Result<Paged<Group>>> Handle(List request)
        {
            var (successResponse, errorResponse) = await _client.GetResponse<ListGroupsResponse, ErrorResponse>(
                _mapper.MapRequestToBroker(request));

            if (errorResponse.IsCompletedSuccessfully)
                return await errorResponse.Parse<Paged<Group>>();

            var groupsResponse = (await successResponse).Message;
            var paged = new Paged<Group>
            {
                Page = groupsResponse.Page,
                PageSize = groupsResponse.PageSize,
                TotalPages = groupsResponse.TotalPages,
                RecordsInPage = groupsResponse.RecordsInPage,
                Items = _mapper.MapResponseToModel(groupsResponse.Items),
                FilterBy = groupsResponse.FilterBy,
                OrderBy = groupsResponse.OrderBy,
                Sorting = groupsResponse.Sorting
            };

            return new Result<Paged<Group>>(paged);
        }
    }
}