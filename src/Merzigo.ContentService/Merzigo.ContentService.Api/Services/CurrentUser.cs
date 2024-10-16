using Merzigo.ContentService.Application.Common.Interfaces;

namespace Merzigo.ContentService.Api.Services
{
    public class CurrentUser : IUser
    {
        public Guid? Id { get; set; }
    }
}
