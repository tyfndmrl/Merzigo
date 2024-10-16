using Mapster;
using Merzigo.UserService.Application.Common.Interfaces;
using Merzigo.UserService.Application.Common.Models;
using Merzigo.UserService.Application.Messaging;
using Microsoft.EntityFrameworkCore;

namespace Merzigo.UserService.Application.Users.Queries.GetUsers
{
    public class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, List<UserDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public GetUsersQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IResult<List<UserDto>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _applicationDbContext.Users.ProjectToType<UserDto>().ToListAsync(cancellationToken);
            return Result.Ok<List<UserDto>>(users);
        }
    }
}
