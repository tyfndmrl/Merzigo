using MediatR;
using Merzigo.ContentService.Domain.Events;
using Microsoft.Extensions.Logging;

namespace Merzigo.ContentService.Application.Contents.EventHandlers
{
    public class ContentDeletedEventHandler : INotificationHandler<ContentDeletedEvent>
    {
        private readonly ILogger<ContentDeletedEventHandler> _logger;

        public ContentDeletedEventHandler(ILogger<ContentDeletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ContentDeletedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("UserService Request");
            return Task.CompletedTask;
        }
    }
}
