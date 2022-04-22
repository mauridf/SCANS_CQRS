using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCANS_CQRS.Context;
using MediatR;
using System.Threading;

namespace SCANS_CQRS.Features.HQFeatures.Commands
{
    public class UpdateHQCommand : IRequest<int>
    {
        public int IdHq { get; set; }
        public string NomeHq { get; set; }
        public string NumeroHq { get; set; }
        public string VolumeHq { get; set; }
        public string DscResumoHq { get; set; }
        public int IdEditora { get; set; }
        public int IdIdioma { get; set; }
        public int IdTipoPublicacao { get; set; }
        public class UpdateHQCommandHandler : IRequestHandler<UpdateHQCommand, int>
        {
            private readonly IScanDbContext _context;
            public UpdateHQCommandHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateHQCommand command, CancellationToken cancellationToken)
            {
                var hq = _context.HQs.Where(a => a.IdHQ == command.IdHq).FirstOrDefault();
                if (hq == null)
                {
                    return default;
                }
                else
                {
                    hq.NomeHQ = command.NomeHq;
                    hq.NumeroHQ = command.NumeroHq;
                    hq.VolumeHQ = command.VolumeHq;
                    hq.DscResumoHQ = command.DscResumoHq;
                    hq.IdEditora = command.IdEditora;
                    hq.IdIdioma = command.IdIdioma;
                    hq.IdTipoPublicacao = command.IdTipoPublicacao;
                    await _context.SaveChangesAsync();
                    return hq.IdHQ;
                }
            }
        }
    }
}
