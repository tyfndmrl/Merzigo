using MediatR;
using Merzigo.ContentService.Application.Common.Models;

namespace Merzigo.ContentService.Application.Messaging
{
    public interface IQuery<TResponse> : IRequest<IResult<TResponse>>;
}
