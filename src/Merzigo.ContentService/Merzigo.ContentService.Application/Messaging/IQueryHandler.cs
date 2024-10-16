using MediatR;
using Merzigo.ContentService.Application.Common.Models;

namespace Merzigo.ContentService.Application.Messaging
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, IResult<TResponse>> where TQuery : IQuery<TResponse>;
}
