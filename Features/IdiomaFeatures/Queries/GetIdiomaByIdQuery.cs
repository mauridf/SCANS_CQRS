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
    public class GetIdiomaByIdQuery : IRequest<Idioma>
    {
        public int IdIdioma { get; set; }
        public class GetIdiomaByIdQueryHandler : IRequestHandler<GetIdiomaByIdQuery, Idioma>
        {
            private readonly IScanDbContext _context;
            public GetIdiomaByIdQueryHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<Idioma> Handle(GetIdiomaByIdQuery query, CancellationToken cancellationToken)
            {
                var idioma = _context.Idiomas.Where(a => a.IdIdioma == query.IdIdioma).FirstOrDefault();
                if (idioma == null) return null;
                return idioma;
            }
        }
    }
}
