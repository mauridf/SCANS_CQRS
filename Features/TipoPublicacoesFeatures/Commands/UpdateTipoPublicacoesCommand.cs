using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCANS_CQRS.Context;
using MediatR;
using System.Threading;

namespace SCANS_CQRS.Features.TipoPublicacoesFeatures.Commands
{
    public class UpdateTipoPublicacoesCommand : IRequest<int>
    {
        public int IdTipoPublicacao { get; set; }
        public string NomeTipoPublicacao { get; set; }
        public class UpdateTipoPublicacoesCommandHandler : IRequestHandler<UpdateTipoPublicacoesCommand, int>
        {
            private readonly IScanDbContext _context;
            public UpdateTipoPublicacoesCommandHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateTipoPublicacoesCommand command, CancellationToken cancellationToken)
            {
                var tipoPublicacao = _context.TipoPublicacoes.Where(a => a.IdTipoPublicacao == command.IdTipoPublicacao).FirstOrDefault();
                if (tipoPublicacao == null)
                {
                    return default;
                }
                else
                {
                    tipoPublicacao.NomeTipoPublicacao = command.NomeTipoPublicacao;
                    await _context.SaveChangesAsync();
                    return tipoPublicacao.IdTipoPublicacao;
                }
            }
        }
    }
}
