using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCANS_CQRS.Context;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SCANS_CQRS.Features.HQPersEquipeFeatures.Commands
{
    public class DeleteHQPersEquipeCommand : IRequest<int>
    {
        public int IdHqPersEquipe { get; set; }
        public class DeleteHQPersEquipeCommandHandler : IRequestHandler<DeleteHQPersEquipeCommand, int>
        {
            private readonly IScanDbContext _context;
            public DeleteHQPersEquipeCommandHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteHQPersEquipeCommand command, CancellationToken cancellationToken)
            {
                var hq_pers_equipe = _context.HQ_PersEquipes.Where(a => a.IdHQPersEquipe == command.IdHqPersEquipe).FirstOrDefault();
                if (hq_pers_equipe == null) return default;
                _context.HQ_PersEquipes.Remove(hq_pers_equipe);
                await _context.SaveChangesAsync();
                return hq_pers_equipe.IdHQPersEquipe;
            }
        }
    }
}
