using SCANS_CQRS.Features.PersEquipeFeature.Commands;
using SCANS_CQRS.Features.PersEquipeFeature.Queries;
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
    public class PersEquipeController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllPersEquipeQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetPersEquipeByIdQuery { IdPersEquipe = id }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreatePersEquipeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePersEquipeCommand command)
        {
            if (id != command.IdPersEquipe)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeletePersEquipeCommand { IdPersEquipe = id }));
        }
    }
}
