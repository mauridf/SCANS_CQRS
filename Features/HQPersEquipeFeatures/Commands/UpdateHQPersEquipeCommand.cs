using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCANS_CQRS.Context;
using MediatR;
using System.Threading;


namespace SCANS_CQRS.Features.HQPersEquipeFeatures.Commands
{
    public class UpdateHQPersEquipeCommand : IRequest<int>
    {
        public int IdHqPersEquipe { get; set; }
        public int IdPersEquipe { get; set; }
        public int IdHQ { get; set; }
        public class UpdateHQPersEquipeCommandHandler : IRequestHandler<UpdateHQPersEquipeCommand, int>
        {
            private readonly IScanDbContext _context;
            public UpdateHQPersEquipeCommandHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateHQPersEquipeCommand command, CancellationToken cancellationToken)
            {
                var hq_pers_equipe = _context.HQ_PersEquipes.Where(a => a.IdHQPersEquipe == command.IdHqPersEquipe).FirstOrDefault();
                if (hq_pers_equipe == null)
                {
                    return default;
                }
                else
                {
                    hq_pers_equipe.IdPersEquipe = command.IdPersEquipe;
                    hq_pers_equipe.IdHQ = command.IdHQ;
                    await _context.SaveChangesAsync();
                    return hq_pers_equipe.IdHQPersEquipe;
                }
            }
        }
    }
}
