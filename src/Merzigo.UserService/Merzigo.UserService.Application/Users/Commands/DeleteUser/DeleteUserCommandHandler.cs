using Merzigo.UserService.Application.Common.Interfaces;
using Merzigo.UserService.Application.Common.Models;
using Merzigo.UserService.Application.Messaging;

namespace Merzigo.UserService.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public DeleteUserCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<IResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.Users.FindAsync(request.Id, cancellationToken);

            if (entity == null)
                return Result.Fail("User not found.");

            _applicationDbContext.Users.Remove(entity);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
