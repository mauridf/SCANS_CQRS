using SCANS_CQRS.Context;
using SCANS_CQRS.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SCANS_CQRS.Features.PersEquipeFeature.Queries
{
    public class GetPersEquipeByIdQuery : IRequest<PersEquipe>
    {
        public int IdPersEquipe { get; set; }
        public class GetPersEquipeByIdQueryHandler : IRequestHandler<GetPersEquipeByIdQuery, PersEquipe>
        {
            private readonly IScanDbContext _context;
            public GetPersEquipeByIdQueryHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<PersEquipe> Handle(GetPersEquipeByIdQuery query, CancellationToken cancellationToken)
            {
                var pers_equipe = _context.PersEquipes.Where(a => a.IdPersEquipe == query.IdPersEquipe).FirstOrDefault();
                if (pers_equipe == null) return null;
                return pers_equipe;
            }
        }
    }
}
