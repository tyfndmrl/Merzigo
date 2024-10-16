using Merzigo.UserService.Application.Messaging;

namespace Merzigo.UserService.Application.Users.Queries.GetUser
{
    public class GetUserQuery : IQuery<UserDto>
    {
        public Guid Id { get; set; }
    }
}
