using Mapster;
using Merzigo.ContentService.Application.Common.Interfaces;
using Merzigo.ContentService.Application.Common.Models;
using Merzigo.ContentService.Application.Messaging;
using Microsoft.EntityFrameworkCore;

namespace Merzigo.ContentService.Application.Contents.Queries.GetContents
{
    public class GetContentsQueryHandler : IQueryHandler<GetContentsQuery, List<ContentDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public GetContentsQueryHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IResult<List<ContentDto>>> Handle(GetContentsQuery request, CancellationToken cancellationToken)
        {
            var users = await _applicationDbContext.Contents.ProjectToType<ContentDto>().ToListAsync(cancellationToken);
            return Result.Ok<List<ContentDto>>(users);
        }
    }
}
