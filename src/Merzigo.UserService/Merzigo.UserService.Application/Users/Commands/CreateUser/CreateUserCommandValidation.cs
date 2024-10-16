using FluentValidation;

namespace Merzigo.UserService.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidation()
        {
            
        }
    }
}
