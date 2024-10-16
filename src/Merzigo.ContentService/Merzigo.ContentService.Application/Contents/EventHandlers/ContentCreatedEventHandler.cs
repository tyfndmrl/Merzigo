using MediatR;
using Merzigo.ContentService.Domain.Events;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merzigo.ContentService.Application.Contents.EventHandlers
{
    public class ContentCreatedEventHandler : INotificationHandler<ContentCreatedEvent>
    {
        private readonly ILogger<ContentCreatedEventHandler> _logger;

        public ContentCreatedEventHandler(ILogger<ContentCreatedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ContentCreatedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("UserService Request");
            return Task.CompletedTask;
        }
    }
}
