using Merzigo.ContentService.Application.Messaging;

namespace Merzigo.ContentService.Application.Contents.Commands.CreateContent
{
    public class CreateContentCommand : ICommand<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public string Tags { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
    }
}
