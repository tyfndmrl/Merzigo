using Merzigo.UserService.Application.Messaging;
using System.Text.Json.Serialization;

namespace Merzigo.UserService.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : ICommand
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
