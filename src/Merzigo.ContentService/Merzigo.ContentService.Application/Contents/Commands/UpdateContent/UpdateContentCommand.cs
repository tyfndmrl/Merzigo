using Merzigo.ContentService.Application.Messaging;
using System.Text.Json.Serialization;

namespace Merzigo.ContentService.Application.Contents.Commands.UpdateContent
{
    public class UpdateContentCommand : ICommand
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public string Tags { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
    }
}
