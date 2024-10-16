using Merzigo.ContentService.Domain.Common;
using Merzigo.ContentService.Domain.Entities;

namespace Merzigo.ContentService.Domain.Events
{
    public class ContentCreatedEvent : BaseEvent
    {
        public ContentCreatedEvent(Content content)
        {
            Content = content;
        }

        public Content Content { get; }
    }
}
