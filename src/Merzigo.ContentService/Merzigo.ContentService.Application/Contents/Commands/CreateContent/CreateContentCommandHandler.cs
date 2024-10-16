using Mapster;
using Merzigo.ContentService.Application.Common.Interfaces;
using Merzigo.ContentService.Application.Common.Models;
using Merzigo.ContentService.Application.Messaging;
using Merzigo.ContentService.Domain.Entities;
using Merzigo.ContentService.Domain.Events;

namespace Merzigo.ContentService.Application.Contents.Commands.CreateContent
{
    public class CreateContentCommandHandler : ICommandHandler<CreateContentCommand, Guid>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public CreateContentCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<IResult<Guid>> Handle(CreateContentCommand request, CancellationToken cancellationToken)
        {
            var entity = request.Adapt<Content>();

            entity.AddDomainEvent(new ContentCreatedEvent(entity));

            _applicationDbContext.Contents.Add(entity);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Result.Ok<Guid>(entity.Id);
        }
    }
}
