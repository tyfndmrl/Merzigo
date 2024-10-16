using Merzigo.ContentService.Domain.Common;
using Merzigo.ContentService.Domain.Entities;

namespace Merzigo.ContentService.Domain.Events
{
    public class ContentDeletedEvent : BaseEvent
    {
        public ContentDeletedEvent(Content content)
        {
            Content = content;
        }

        public Content Content { get; }
    }
}
