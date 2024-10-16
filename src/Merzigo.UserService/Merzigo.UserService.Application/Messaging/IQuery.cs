using MediatR;
using Merzigo.UserService.Application.Common.Models;

namespace Merzigo.UserService.Application.Messaging
{
    public interface IQuery<TResponse> : IRequest<IResult<TResponse>>;
}
