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
    public class GetAllHQPersEquipeQuery : IRequest<IEnumerable<HQ_PersEquipe>>
    {
        public class GetAllHQPersEquipeQueryHandler : IRequestHandler<GetAllHQPersEquipeQuery, IEnumerable<HQ_PersEquipe>>
        {
            private readonly IScanDbContext _context;
            public GetAllHQPersEquipeQueryHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<HQ_PersEquipe>> Handle(GetAllHQPersEquipeQuery query, CancellationToken cancellationToken)
            {
                var hq_pers_equipeList = await _context.HQ_PersEquipes.ToListAsync();
                if (hq_pers_equipeList == null)
                {
                    return null;
                }
                return hq_pers_equipeList.AsReadOnly();
            }
        }
    }
}
