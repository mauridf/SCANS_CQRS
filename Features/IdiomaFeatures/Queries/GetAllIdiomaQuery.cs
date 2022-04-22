using SCANS_CQRS.Context;
using SCANS_CQRS.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SCANS_CQRS.Features.IdiomaFeatures.Queries
{
    public class GetAllIdiomaQuery : IRequest<IEnumerable<Idioma>>
    {
        public class GetAllIdiomaQueryHandler : IRequestHandler<GetAllIdiomaQuery, IEnumerable<Idioma>>
        {
            private readonly IScanDbContext _context;
            public GetAllIdiomaQueryHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Idioma>> Handle(GetAllIdiomaQuery query, CancellationToken cancellationToken)
            {
                var idiomaList = await _context.Idiomas.ToListAsync();
                if (idiomaList == null)
                {
                    return null;
                }
                return idiomaList.AsReadOnly();
            }
        }
    }
}
