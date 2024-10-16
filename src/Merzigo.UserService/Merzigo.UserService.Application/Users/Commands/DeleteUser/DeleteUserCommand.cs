using Merzigo.UserService.Application.Messaging;

namespace Merzigo.UserService.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
