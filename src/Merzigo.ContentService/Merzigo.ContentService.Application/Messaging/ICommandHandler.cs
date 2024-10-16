using MediatR;
using Merzigo.ContentService.Application.Common.Models;

namespace Merzigo.ContentService.Application.Messaging
{
    public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, IResult> where TCommand : ICommand;

    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, IResult<TResponse>> where TCommand : ICommand<TResponse>;
}
