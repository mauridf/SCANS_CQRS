using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCANS_CQRS.Context;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SCANS_CQRS.Features.IdiomaFeatures.Commands
{
    public class DeleteIdiomaCommand : IRequest<int>
    {
        public int IdIdioma { get; set; }

        public class DeleteIdiomaCommandHandler : IRequestHandler<DeleteIdiomaCommand, int>
        {
            private readonly IScanDbContext _context;
            public DeleteIdiomaCommandHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteIdiomaCommand command, CancellationToken cancellationToken)
            {
                var idioma = _context.Idiomas.Where(a => a.IdIdioma == command.IdIdioma).FirstOrDefault();
                if (idioma == null) return default;
                _context.Idiomas.Remove(idioma);
                await _context.SaveChangesAsync();
                return idioma.IdIdioma;
            }
        }
    }
}
