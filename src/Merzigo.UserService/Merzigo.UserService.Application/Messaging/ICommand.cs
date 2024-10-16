using MediatR;
using Merzigo.UserService.Application.Common.Models;

namespace Merzigo.UserService.Application.Messaging
{
    public interface ICommand : IRequest<IResult>;

    public interface ICommand<TResponse> : IRequest<IResult<TResponse>>;
}
