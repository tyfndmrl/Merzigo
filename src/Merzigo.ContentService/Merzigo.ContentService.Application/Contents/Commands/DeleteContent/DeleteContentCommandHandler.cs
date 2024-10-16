using Merzigo.ContentService.Application.Common.Interfaces;
using Merzigo.ContentService.Application.Common.Models;
using Merzigo.ContentService.Application.Messaging;
using Merzigo.ContentService.Domain.Events;

namespace Merzigo.ContentService.Application.Contents.Commands.DeleteContent
{
    public class DeleteContentCommandHandler : ICommandHandler<DeleteContentCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public DeleteContentCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<IResult> Handle(DeleteContentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.Contents.FindAsync(request.Id, cancellationToken);

            if (entity == null)
                return Result.Fail("Content not found.");

            entity.AddDomainEvent(new ContentDeletedEvent(entity));

            _applicationDbContext.Contents.Remove(entity);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Result.Ok();
        }
    }
}
