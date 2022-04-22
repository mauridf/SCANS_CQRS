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
    public class GetAllPersEquipeQuery : IRequest<IEnumerable<PersEquipe>>
    {
        public class GetAllPersEquipeQueryHandler : IRequestHandler<GetAllPersEquipeQuery, IEnumerable<PersEquipe>>
        {
            private readonly IScanDbContext _context;
            public GetAllPersEquipeQueryHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<PersEquipe>> Handle(GetAllPersEquipeQuery query, CancellationToken cancellationToken)
            {
                var pers_equipe = await _context.PersEquipes.ToListAsync();
                if (pers_equipe == null)
                {
                    return null;
                }
                return pers_equipe.AsReadOnly();
            }
        }
    }
}
