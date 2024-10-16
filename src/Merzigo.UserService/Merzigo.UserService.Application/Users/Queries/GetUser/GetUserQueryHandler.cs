using Mapster;
using Merzigo.UserService.Application.Common.Interfaces;
using Merzigo.UserService.Application.Common.Models;
using Merzigo.UserService.Application.Messaging;

namespace Merzigo.UserService.Application.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IQueryHandler<GetUserQuery, UserDto>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public GetUserQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<IResult<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.Users.FindAsync(request.Id, cancellationToken);

            if (entity == null) {
                return Result.Fail<UserDto>("User not found.");
            }

            return Result.Ok<UserDto>(entity.Adapt<UserDto>());
        }
    }
}
