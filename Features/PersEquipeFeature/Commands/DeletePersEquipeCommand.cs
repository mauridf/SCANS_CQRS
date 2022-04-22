using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCANS_CQRS.Context;
using MediatR;
using System.Threading;


namespace SCANS_CQRS.Features.PersEquipeFeature.Commands
{
    public class DeletePersEquipeCommand : IRequest<int>
    {
        public int IdPersEquipe { get; set; }
        public class DeletePersEquipeCommandHandler : IRequestHandler<DeletePersEquipeCommand, int>
        {
            private readonly IScanDbContext _context;
            public DeletePersEquipeCommandHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeletePersEquipeCommand command, CancellationToken cancellationToken)
            {
                var pers_equipe = _context.PersEquipes.Where(a => a.IdPersEquipe == command.IdPersEquipe).FirstOrDefault();
                if (pers_equipe == null) return default;
                _context.PersEquipes.Remove(pers_equipe);
                await _context.SaveChangesAsync();
                return pers_equipe.IdPersEquipe;
            }
        }
    }
}
