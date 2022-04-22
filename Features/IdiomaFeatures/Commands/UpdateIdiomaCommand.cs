using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCANS_CQRS.Context;
using MediatR;
using System.Threading;

namespace SCANS_CQRS.Features.IdiomaFeatures.Commands
{
    public class UpdateIdiomaCommand : IRequest<int>
    {
        public int IdIdioma { get; set; }
        public string NomeIdioma { get; set; }

        public class UpdateIdiomaCommandHandler : IRequestHandler<UpdateIdiomaCommand, int>
        {
            private readonly IScanDbContext _context;
            public UpdateIdiomaCommandHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateIdiomaCommand command, CancellationToken cancellationToken)
            {
                var idioma = _context.Idiomas.Where(a => a.IdIdioma == command.IdIdioma).FirstOrDefault();
                if (idioma == null)
                {
                    return default;
                }
                else
                {
                    idioma.NomeIdioma = command.NomeIdioma;
                    await _context.SaveChangesAsync();
                    return idioma.IdIdioma;
                }
            }
        }
    }
}
