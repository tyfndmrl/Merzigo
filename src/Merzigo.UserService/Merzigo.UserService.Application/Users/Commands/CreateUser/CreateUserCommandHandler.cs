using Mapster;
using Merzigo.UserService.Application.Common.Interfaces;
using Merzigo.UserService.Application.Common.Models;
using Merzigo.UserService.Application.Messaging;
using Merzigo.UserService.Domain.Entities;

namespace Merzigo.UserService.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Guid>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public CreateUserCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IResult<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Adapt<User>();
            _applicationDbContext.Users.Add(entity);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Result.Ok<Guid>(entity.Id);
        }
    }
}
