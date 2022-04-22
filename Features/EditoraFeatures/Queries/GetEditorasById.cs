using SCANS_CQRS.Context;
using SCANS_CQRS.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SCANS_CQRS.Features.EditoraFeatures.Queries
{
    public class GetEditorasById : IRequest<Editora>
    {
        public int IdEditora { get; set; }
        public class GetEditorasByIdHandler : IRequestHandler<GetEditorasById, Editora>
        {
            private readonly IScanDbContext _context;
            public GetEditorasByIdHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<Editora> Handle(GetEditorasById query, CancellationToken cancellationToken)
            {
                var editora = _context.Editoras.Where(a => a.IdEditora == query.IdEditora).FirstOrDefault();
                if (editora == null) return null;
                return editora;
            }
        }
    }
}
