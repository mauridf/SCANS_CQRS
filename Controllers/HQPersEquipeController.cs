using SCANS_CQRS.Features.HQPersEquipeFeatures.Commands;
using SCANS_CQRS.Features.HQPersEquipeFeatures.Queries;
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
    public class HQPersEquipeController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllHQPersEquipeQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetHQPersEquipeByIdQuery { IdHQPersEquipe = id }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateHQPersEquipeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateHQPersEquipeCommand command)
        {
            if (id != command.IdHqPersEquipe)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteHQPersEquipeCommand { IdHqPersEquipe = id }));
        }
    }
}
