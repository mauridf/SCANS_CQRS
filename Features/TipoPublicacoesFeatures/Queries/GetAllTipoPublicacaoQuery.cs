using SCANS_CQRS.Context;
using SCANS_CQRS.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SCANS_CQRS.Features.TipoPublicacoesFeatures.Queries
{
    public class GetAllTipoPublicacaoQuery : IRequest<IEnumerable<TipoPublicacao>>
    {
        public class GetAllTipoPublicacaoQueryHandler : IRequestHandler<GetAllTipoPublicacaoQuery, IEnumerable<TipoPublicacao>>
        {
            private readonly IScanDbContext _context;
            public GetAllTipoPublicacaoQueryHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<TipoPublicacao>> Handle(GetAllTipoPublicacaoQuery query, CancellationToken cancellationToken)
            {
                var tipoPublicacaoList = await _context.TipoPublicacoes.ToListAsync();
                if (tipoPublicacaoList == null)
                {
                    return null;
                }
                return tipoPublicacaoList.AsReadOnly();
            }
        }
    }
}
