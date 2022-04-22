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
    public class GetTipoPublicacaoByIdQuery : IRequest<TipoPublicacao>
    {
        public int IdTipoPublicacao{ get; set; }
        public class GetTipoPublicacaoByIdQueryHandler : IRequestHandler<GetTipoPublicacaoByIdQuery, TipoPublicacao>
        {
            private readonly IScanDbContext _context;
            public GetTipoPublicacaoByIdQueryHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<TipoPublicacao> Handle(GetTipoPublicacaoByIdQuery query, CancellationToken cancellationToken)
            {
                var tipoPublicacao = _context.TipoPublicacoes.Where(a => a.IdTipoPublicacao == query.IdTipoPublicacao).FirstOrDefault();
                if (tipoPublicacao == null) return null;
                return tipoPublicacao;
            }
        }
    }
}
