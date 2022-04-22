using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCANS_CQRS.Context;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SCANS_CQRS.Features.TipoPublicacoesFeatures.Commands
{
    public class DeleteTipoPublicacoesCommand : IRequest<int>
    {
        public int IdTipoPublicacao {get;set;}
        public class DeleteTipoPublicacoesCommandHandler : IRequestHandler<DeleteTipoPublicacoesCommand, int>
        {
            private readonly IScanDbContext _context;
            public DeleteTipoPublicacoesCommandHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteTipoPublicacoesCommand command, CancellationToken cancellationToken)
            {
                var tipoPublicacao = _context.TipoPublicacoes.Where(a => a.IdTipoPublicacao == command.IdTipoPublicacao).FirstOrDefault();
                if (tipoPublicacao == null) return default;
                _context.TipoPublicacoes.Remove(tipoPublicacao);
                await _context.SaveChangesAsync();
                return tipoPublicacao.IdTipoPublicacao;
            }
        }
    }
}
