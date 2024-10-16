using Merzigo.UserService.Application.Messaging;

namespace Merzigo.UserService.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : ICommand<Guid>
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
