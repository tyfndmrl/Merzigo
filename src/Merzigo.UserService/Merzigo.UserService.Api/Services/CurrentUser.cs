using Merzigo.UserService.Application.Common.Interfaces;

namespace Merzigo.UserService.Api.Services
{
    public class CurrentUser : IUser
    {
        public Guid? Id { get; set; }
    }
}
