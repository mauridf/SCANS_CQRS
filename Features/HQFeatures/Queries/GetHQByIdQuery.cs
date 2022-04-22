using SCANS_CQRS.Context;
using SCANS_CQRS.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SCANS_CQRS.Features.HQFeatures.Queries
{
    public class GetHQByIdQuery : IRequest<HQ>
    {
        public int IdHQ { get; set; }
        public class GetHQByIdQueryHandler : IRequestHandler<GetHQByIdQuery, HQ>
        {
            private readonly IScanDbContext _context;
            public GetHQByIdQueryHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<HQ> Handle(GetHQByIdQuery query, CancellationToken cancellationToken)
            {
                var hq = _context.HQs.Where(a => a.IdHQ == query.IdHQ).FirstOrDefault();
                if (hq == null) return null;
                return hq;
            }
        }
    }
}
