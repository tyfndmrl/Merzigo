using Merzigo.ContentService.Application.Messaging;

namespace Merzigo.ContentService.Application.Contents.Queries.GetContent
{
    public class GetContentQuery : IQuery<ContentDto>
    {
        public Guid Id { get; set; }
    }
}
