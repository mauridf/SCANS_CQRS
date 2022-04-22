using SCANS_CQRS.Features.TipoPublicacoesFeatures.Commands;
using SCANS_CQRS.Features.TipoPublicacoesFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace SCANS_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPublicacaoController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllTipoPublicacaoQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetTipoPublicacaoByIdQuery { IdTipoPublicacao = id }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTipoPublicacoesCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTipoPublicacoesCommand command)
        {
            if (id != command.IdTipoPublicacao)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteTipoPublicacoesCommand { IdTipoPublicacao = id }));
        }
    }
}
