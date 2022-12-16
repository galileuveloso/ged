using Ged.Api.Features.ArquivoFeature.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ged.Api.Features.ArquivoFeature
{
    [Route("arquivo")]
    [ApiController]
    public class ArquivoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArquivoController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ActionResult> Post(InserirArquivoCommand request)
        {
            try
            {
                return Ok(await _mediator.Send(request));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
