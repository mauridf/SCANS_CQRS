using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SCANS_CQRS.Context;
using SCANS_CQRS.Entity;

namespace SCANS_CQRS.Features.IdiomaFeatures.Commands
{
    public class CreateIdiomaCommand : IRequest<int>
    {
        public int IdIdioma { get; set; }
        public string NomeIdioma { get; set; }

        public class CreateIdiomaCommandHandler : IRequestHandler<CreateIdiomaCommand, int>
        {
            private readonly IScanDbContext _context;
            public CreateIdiomaCommandHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateIdiomaCommand command, CancellationToken cancellationToken)
            {
                var idioma = new Idioma();
                idioma.IdIdioma = command.IdIdioma;
                idioma.NomeIdioma = command.NomeIdioma;
                _context.Idiomas.Add(idioma);
                await _context.SaveChangesAsync();
                return idioma.IdIdioma;
            }
        }
    }
}
