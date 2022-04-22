using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCANS_CQRS.Context;
using MediatR;
using System.Threading;

namespace SCANS_CQRS.Features.PersEquipeFeature.Commands
{
    public class UpdatePersEquipeCommand : IRequest<int>
    {
        public int IdPersEquipe { get; set; }
        public string NomePersEquipe { get; set; }
        public string DscPersEquipe { get; set; }
        public class UpdatePersEquipeCommandHandler : IRequestHandler<UpdatePersEquipeCommand, int>
        {
            private readonly IScanDbContext _context;
            public UpdatePersEquipeCommandHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdatePersEquipeCommand command, CancellationToken cancellationToken)
            {
                var pers_equipe = _context.PersEquipes.Where(a => a.IdPersEquipe == command.IdPersEquipe).FirstOrDefault();
                if (pers_equipe == null)
                {
                    return default;
                }
                else
                {
                    pers_equipe.NomePersEquipe = command.NomePersEquipe;
                    pers_equipe.DscPersEquipe = command.DscPersEquipe;
                    await _context.SaveChangesAsync();
                    return pers_equipe.IdPersEquipe;
                }
            }
        }
    }
}
