namespace Identity.Api.Services.UserTypeService.Handlers
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

    public class GetHandler : QueryHandler<Get, UserType>
    {
        private readonly IRequestClient<GetUserType> _client;
        private readonly IUserTypeMapper _mapper;

        public GetHandler(IRequestClient<GetUserType> client, IUserTypeMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        protected override async Task<Result<UserType>> Handle(Get request)
        {
            var (successResponse, errorResponse) =
                await _client.GetResponse<UserTypeResponse, ErrorResponse>(_mapper.MapRequestToBroker(request));

            if (errorResponse.IsCompletedSuccessfully)
                return await errorResponse.Parse<UserType>();

            var userType = (await successResponse).Message;
            return new Result<UserType>(_mapper.MapResponseToModel(userType));
        }
    }
}