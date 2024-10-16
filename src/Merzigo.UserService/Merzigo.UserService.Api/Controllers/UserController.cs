using MediatR;
using Merzigo.UserService.Application.Users.Commands.CreateUser;
using Merzigo.UserService.Application.Users.Commands.DeleteUser;
using Merzigo.UserService.Application.Users.Commands.UpdateUser;
using Merzigo.UserService.Application.Users.Queries.GetUser;
using Merzigo.UserService.Application.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;

namespace Merzigo.UserService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISender _sender;
        public UserController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> UserAsync(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserAsync(Guid id, UpdateUserCommand command, CancellationToken cancellationToken)
        {
            command.Id = id;
            var result = await _sender.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteUserCommand { Id = id };
            var result = await _sender.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserAsync(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery { Id = id };
            var result = await _sender.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAsync(CancellationToken cancellationToken)
        {
            var query = new GetUsersQuery();
            var result = await _sender.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
