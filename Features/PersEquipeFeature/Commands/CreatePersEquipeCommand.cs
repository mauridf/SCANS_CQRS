using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SCANS_CQRS.Context;
using SCANS_CQRS.Entity;

namespace SCANS_CQRS.Features.PersEquipeFeature.Commands
{
    public class CreatePersEquipeCommand : IRequest<int>
    {
        public int IdPersEquipe { get; set; }
        public string NomePersEquipe { get; set; }
        public string DscPersEquipe { get; set; }
        public class CreatePersEquipeCommandHandler : IRequestHandler<CreatePersEquipeCommand, int>
        {
            private readonly IScanDbContext _context;
            public CreatePersEquipeCommandHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreatePersEquipeCommand command, CancellationToken cancellationToken)
            {
                var pers_equipe = new PersEquipe();
                pers_equipe.IdPersEquipe = command.IdPersEquipe;
                pers_equipe.NomePersEquipe = command.NomePersEquipe;
                pers_equipe.DscPersEquipe = command.DscPersEquipe;
                _context.PersEquipes.Add(pers_equipe);
                await _context.SaveChangesAsync();
                return pers_equipe.IdPersEquipe;
            }
        }
    }
}
