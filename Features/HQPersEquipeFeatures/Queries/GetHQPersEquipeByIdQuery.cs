using SCANS_CQRS.Context;
using SCANS_CQRS.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace SCANS_CQRS.Features.HQPersEquipeFeatures.Queries
{
    public class GetHQPersEquipeByIdQuery : IRequest<HQ_PersEquipe>
    {
        public int IdHQPersEquipe { get; set; }
        public class GetHQPersEquipeByIdQueryHandler : IRequestHandler<GetHQPersEquipeByIdQuery, HQ_PersEquipe>
        {
            private readonly IScanDbContext _context;
            public GetHQPersEquipeByIdQueryHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<HQ_PersEquipe> Handle(GetHQPersEquipeByIdQuery query, CancellationToken cancellationToken)
            {
                var hq_pers_equipe = _context.HQ_PersEquipes.Where(a => a.IdHQPersEquipe == query.IdHQPersEquipe).FirstOrDefault();
                if (hq_pers_equipe == null) return null;
                return hq_pers_equipe;
            }
        }
    }
}
