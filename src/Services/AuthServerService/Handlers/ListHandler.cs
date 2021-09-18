namespace Identity.Api.Services.AuthServerService.Handlers
{
    using System.Threading.Tasks;
    using AlbedoTeam.Identity.Contracts.Requests;
    using AlbedoTeam.Identity.Contracts.Responses;
    using AlbedoTeam.Sdk.FailFast;
    using AlbedoTeam.Sdk.FailFast.Abstractions;
    using Extensions;
    using Mappers.Abstractions;
    using MassTransit;
    using Models;
    using Requests;

    public class ListHandler : QueryHandler<List, Paged<AuthServer>>
    {
        private readonly IRequestClient<ListAuthServers> _client;
        private readonly IAuthServerMapper _mapper;

        public ListHandler(IRequestClient<ListAuthServers> client, IAuthServerMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        protected override async Task<Result<Paged<AuthServer>>> Handle(List request)
        {
            var (successResponse, errorResponse) = await _client.GetResponse<ListAuthServersResponse, ErrorResponse>(
                _mapper.MapRequestToBroker(request));

            if (errorResponse.IsCompletedSuccessfully)
                return await errorResponse.Parse<Paged<AuthServer>>();

            var authServersResponse = (await successResponse).Message;
            var paged = new Paged<AuthServer>
            {
                Page = authServersResponse.Page,
                PageSize = authServersResponse.PageSize,
                TotalPages = authServersResponse.TotalPages,
                RecordsInPage = authServersResponse.RecordsInPage,
                Items = _mapper.MapResponseToModel(authServersResponse.Items),
                FilterBy = authServersResponse.FilterBy,
                OrderBy = authServersResponse.OrderBy,
                Sorting = authServersResponse.Sorting
            };

            return new Result<Paged<AuthServer>>(paged);
        }
    }
}