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
    public class GetAllEditoras : IRequest<IEnumerable<Editora>>
    {
        public class GetAllEditorasHandler : IRequestHandler<GetAllEditoras, IEnumerable<Editora>>
        {
            private readonly IScanDbContext _context;
            public GetAllEditorasHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Editora>> Handle(GetAllEditoras query, CancellationToken cancellationToken)
            {
                var editoraList = await _context.Editoras.ToListAsync();
                if (editoraList == null)
                {
                    return null;
                }
                return editoraList.AsReadOnly();
            }
        }
    }
}
