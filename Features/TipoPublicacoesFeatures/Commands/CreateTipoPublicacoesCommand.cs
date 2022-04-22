using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SCANS_CQRS.Context;
using SCANS_CQRS.Entity;

namespace SCANS_CQRS.Features.TipoPublicacoesFeatures.Commands
{
    public class CreateTipoPublicacoesCommand : IRequest<int>
    {
        public int IdTipoPublicacao { get; set; }
        public string NomeTipoPublicacao { get; set; }
        public class CreateTipoPublicacoesCommandHandler : IRequestHandler<CreateTipoPublicacoesCommand, int>
        {
            private readonly IScanDbContext _context;
            public CreateTipoPublicacoesCommandHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateTipoPublicacoesCommand command, CancellationToken cancellationToken)
            {
                var tipoPublicacao = new TipoPublicacao();
                tipoPublicacao.IdTipoPublicacao = command.IdTipoPublicacao;
                tipoPublicacao.NomeTipoPublicacao = command.NomeTipoPublicacao;
                _context.TipoPublicacoes.Add(tipoPublicacao);
                await _context.SaveChangesAsync();
                return tipoPublicacao.IdTipoPublicacao;
            }
        }
    }
}
