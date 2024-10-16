using Mapster;
using Merzigo.UserService.Application.Users.Commands.CreateUser;
using Merzigo.UserService.Application.Users.Commands.UpdateUser;
using Merzigo.UserService.Domain.Entities;

namespace Merzigo.UserService.Application.Common.Mappings
{
    public static class MappingProfile
    {
        public static void Map()
        {
            TypeAdapterConfig<CreateUserCommand, User>.NewConfig();
            TypeAdapterConfig<UpdateUserCommand, User>.NewConfig();

            TypeAdapterConfig<User, Users.Queries.GetUser.UserDto>.NewConfig();
            TypeAdapterConfig<User, Users.Queries.GetUsers.UserDto>.NewConfig();
        }
    }
}
