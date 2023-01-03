using Ged.Api.Features.ArquivoFeature.Commands;
using Ged.Api.Features.ArquivoFeature.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Core;

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

        [HttpPut]
        public async Task<ActionResult> Put(AtualizarArquivoCommand request)
        {
            try
            {
                return Ok(await _mediator.Send(request));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ObjectNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                return Ok(await _mediator.Send(new RemoverArquivoCommand(id)));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ObjectNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                return Ok(await _mediator.Send(new ObterArquivoByIdQuery { IdArquivo = id }));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ObjectNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpGet("listar/{idsArquivos}")]
        public async Task<ActionResult> Get(IEnumerable<long> ids)
        {
            try
            {
                return Ok(await _mediator.Send(new SelecionarArquivosByIdQuery { Ids = ids }));
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ObjectNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

    }
}
