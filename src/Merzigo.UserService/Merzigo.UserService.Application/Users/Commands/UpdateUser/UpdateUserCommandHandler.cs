using Mapster;
using Merzigo.UserService.Application.Common.Interfaces;
using Merzigo.UserService.Application.Common.Models;
using Merzigo.UserService.Application.Messaging;

namespace Merzigo.UserService.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public UpdateUserCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<IResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.Users.FindAsync(request.Id, cancellationToken);

            if (entity == null)
                return Result.Fail("User not found.");

            entity = request.Adapt(entity);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}
