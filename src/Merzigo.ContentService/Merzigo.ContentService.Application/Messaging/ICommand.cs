using MediatR;
using Merzigo.ContentService.Application.Common.Models;

namespace Merzigo.ContentService.Application.Messaging
{
    public interface ICommand : IRequest<IResult>;

    public interface ICommand<TResponse> : IRequest<IResult<TResponse>>;
}
