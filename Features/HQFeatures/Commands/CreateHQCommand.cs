using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SCANS_CQRS.Context;
using SCANS_CQRS.Entity;

namespace SCANS_CQRS.Features.HQFeatures.Commands
{
    public class CreateHQCommand : IRequest<int>
    {
        public int IdHq { get; set; }
        public string NomeHq { get; set; }
        public string NumeroHq { get; set; }
        public string VolumeHq { get; set; }
        public string DscResumoHq { get; set; }
        public int IdEditora { get; set; }
        public int IdIdioma { get; set; }
        public int IdTipoPublicacao { get; set; }
        public class CreateHQCommandHandler : IRequestHandler<CreateHQCommand, int>
        {
            private readonly IScanDbContext _context;
            public CreateHQCommandHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateHQCommand command, CancellationToken cancellationToken)
            {
                var hq = new HQ();
                hq.IdHQ = command.IdHq;
                hq.NomeHQ = command.NomeHq;
                hq.NumeroHQ = command.NumeroHq;
                hq.VolumeHQ = command.VolumeHq;
                hq.DscResumoHQ = command.DscResumoHq;
                hq.IdEditora = command.IdEditora;
                hq.IdIdioma = command.IdIdioma;
                hq.IdTipoPublicacao = command.IdTipoPublicacao;
                _context.HQs.Add(hq);
                await _context.SaveChangesAsync();
                return hq.IdHQ;
            }
        }
    }
}
