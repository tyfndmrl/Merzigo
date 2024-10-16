using Mapster;
using Merzigo.ContentService.Application.Common.Interfaces;
using Merzigo.ContentService.Application.Common.Models;
using Merzigo.ContentService.Application.Messaging;

namespace Merzigo.ContentService.Application.Contents.Commands.UpdateContent
{
    public class UpdateContentCommandHandler : ICommandHandler<UpdateContentCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public UpdateContentCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<IResult> Handle(UpdateContentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.Contents.FindAsync(request.Id, cancellationToken);

            if (entity == null)
                return Result.Fail("Content not found.");

            entity = request.Adapt(entity);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return Result.Ok();
        }
    }
}
