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
    }
}
