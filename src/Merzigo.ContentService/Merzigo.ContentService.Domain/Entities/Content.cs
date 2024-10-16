using Merzigo.ContentService.Domain.Common;
using Merzigo.ContentService.Domain.Common.Auditing.Interfaces;

namespace Merzigo.ContentService.Domain.Entities
{
    public class Content : AuditableEntity<Guid>, ISoftDelete
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public string Tags { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public bool IsDeleted { get; set; }
    }
}
