using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SCANS_CQRS.Context;
using SCANS_CQRS.Entity;

namespace SCANS_CQRS.Features.HQPersEquipeFeatures.Commands
{
    public class CreateHQPersEquipeCommand : IRequest<int>
    {
        public int IdHqPersEquipe { get; set; }
        public int IdPersEquipe { get; set; }
        public int IdHQ { get; set; }
        public class CreateHQPersEquipeCommandHandler : IRequestHandler<CreateHQPersEquipeCommand, int>
        {
            private readonly IScanDbContext _context;
            public CreateHQPersEquipeCommandHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateHQPersEquipeCommand command, CancellationToken cancellationToken)
            {
                var hq_pers_equipe = new HQ_PersEquipe();
                hq_pers_equipe.IdHQPersEquipe = command.IdHqPersEquipe;
                hq_pers_equipe.IdPersEquipe = command.IdPersEquipe;
                hq_pers_equipe.IdHQ = command.IdHQ;
                _context.HQ_PersEquipes.Add(hq_pers_equipe);
                await _context.SaveChangesAsync();
                return hq_pers_equipe.IdHQPersEquipe;
            }
        }
    }
}
