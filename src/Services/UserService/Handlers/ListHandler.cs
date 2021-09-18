namespace Identity.Api.Services.UserService.Handlers
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

    public class ListHandler : QueryHandler<List, Paged<User>>
    {
        private readonly IRequestClient<ListUsers> _client;
        private readonly IUserMapper _mapper;

        public ListHandler(IRequestClient<ListUsers> client, IUserMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        protected override async Task<Result<Paged<User>>> Handle(List request)
        {
            var (successResponse, errorResponse) = await _client.GetResponse<ListUsersResponse, ErrorResponse>(
                _mapper.MapRequestToBroker(request));

            if (errorResponse.IsCompletedSuccessfully)
                return await errorResponse.Parse<Paged<User>>();

            var usersResponse = (await successResponse).Message;
            var paged = new Paged<User>
            {
                Page = usersResponse.Page,
                PageSize = usersResponse.PageSize,
                TotalPages = usersResponse.TotalPages,
                RecordsInPage = usersResponse.RecordsInPage,
                Items = _mapper.MapResponseToModel(usersResponse.Items),
                FilterBy = usersResponse.FilterBy,
                OrderBy = usersResponse.OrderBy,
                Sorting = usersResponse.Sorting
            };

            return new Result<Paged<User>>(paged);
        }
    }
}