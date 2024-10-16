using Mapster;
using Merzigo.ContentService.Application.Common.Interfaces;
using Merzigo.ContentService.Application.Common.Models;
using Merzigo.ContentService.Application.Messaging;

namespace Merzigo.ContentService.Application.Contents.Queries.GetContent
{
    public class GetContentQueryHandler : IQueryHandler<GetContentQuery, ContentDto>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public GetContentQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<IResult<ContentDto>> Handle(GetContentQuery request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.Contents.FindAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                return Result.Fail<ContentDto>("Content not found.");
            }

            return Result.Ok<ContentDto>(entity.Adapt<ContentDto>());
        }
    }
}
