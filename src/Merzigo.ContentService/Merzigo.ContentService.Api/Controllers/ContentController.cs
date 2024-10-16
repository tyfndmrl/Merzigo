using MediatR;
using Merzigo.ContentService.Application.Contents.Commands.CreateContent;
using Merzigo.ContentService.Application.Contents.Commands.DeleteContent;
using Merzigo.ContentService.Application.Contents.Commands.UpdateContent;
using Merzigo.ContentService.Application.Contents.Queries.GetContent;
using Merzigo.ContentService.Application.Contents.Queries.GetContents;
using Microsoft.AspNetCore.Mvc;

namespace Merzigo.ContentService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly ISender _sender;
        public ContentController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> ContentAsync(CreateContentCommand command, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContentAsync(Guid id, UpdateContentCommand command, CancellationToken cancellationToken)
        {
            command.Id = id;
            var result = await _sender.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContentAsync(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteContentCommand { Id = id };
            var result = await _sender.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContentAsync(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetContentQuery { Id = id };
            var result = await _sender.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetContentsAsync(CancellationToken cancellationToken)
        {
            var query = new GetContentsQuery();
            var result = await _sender.Send(query, cancellationToken);
            return Ok(result);
        }
    }
}
