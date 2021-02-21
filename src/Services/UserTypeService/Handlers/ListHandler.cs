using System.Threading.Tasks;
using AlbedoTeam.Identity.Contracts.Requests;
using AlbedoTeam.Identity.Contracts.Responses;
using AlbedoTeam.Sdk.FailFast;
using AlbedoTeam.Sdk.FailFast.Abstractions;
using Identity.Api.Extensions;
using Identity.Api.Mappers.Abstractions;
using Identity.Api.Models;
using Identity.Api.Services.UserTypeService.Requests;
using MassTransit;

namespace Identity.Api.Services.UserTypeService.Handlers
{
    public class ListHandler : QueryHandler<List, Paged<UserType>>
    {
        private readonly IRequestClient<ListUserTypes> _client;
        private readonly IUserTypeMapper _mapper;

        public ListHandler(IRequestClient<ListUserTypes> client, IUserTypeMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        protected override async Task<Result<Paged<UserType>>> Handle(List request)
        {
            var (successResponse, errorResponse) = await _client.GetResponse<ListUserTypesResponse, ErrorResponse>(
                _mapper.MapRequestToBroker(request));

            if (errorResponse.IsCompletedSuccessfully)
                return await errorResponse.Parse<Paged<UserType>>();

            var userTypesResponse = (await successResponse).Message;
            var paged = new Paged<UserType>
            {
                Page = userTypesResponse.Page,
                PageSize = userTypesResponse.PageSize,
                TotalPages = userTypesResponse.TotalPages,
                RecordsInPage = userTypesResponse.RecordsInPage,
                Items = _mapper.MapResponseToModel(userTypesResponse.Items),
                FilterBy = userTypesResponse.FilterBy,
                OrderBy = userTypesResponse.OrderBy,
                Sorting = userTypesResponse.Sorting
            };

            return new Result<Paged<UserType>>(paged);
        }
    }
}