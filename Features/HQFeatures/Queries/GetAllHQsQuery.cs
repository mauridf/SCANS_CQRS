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
    public class GetAllHQsQuery : IRequest<IEnumerable<HQ>>
    {
        public class GetAllHQsQueryHandler : IRequestHandler<GetAllHQsQuery, IEnumerable<HQ>>
        {
            private readonly IScanDbContext _context;
            public GetAllHQsQueryHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<HQ>> Handle(GetAllHQsQuery query, CancellationToken cancellationToken)
            {
                var hqList = await _context.HQs.ToListAsync();
                if (hqList == null)
                {
                    return null;
                }
                return hqList.AsReadOnly();
            }
        }
    }
}
