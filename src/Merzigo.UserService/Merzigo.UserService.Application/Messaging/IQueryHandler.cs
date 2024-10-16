using MediatR;
using Merzigo.UserService.Application.Common.Models;

namespace Merzigo.UserService.Application.Messaging
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, IResult<TResponse>> where TQuery : IQuery<TResponse>;
}
