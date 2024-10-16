using Merzigo.ContentService.Application.Messaging;

namespace Merzigo.ContentService.Application.Contents.Commands.DeleteContent
{
    public class DeleteContentCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
