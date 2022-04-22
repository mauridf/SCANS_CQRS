using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCANS_CQRS.Context;
using MediatR;
using System.Threading;

namespace SCANS_CQRS.Features.EditoraFeatures.Commands
{
    public class UpdateEditoraCommand : IRequest<int>
    {
        public int IdEditora { get; set; }
        public string NomeEditora { get; set; }

        public class UpdateEditoraCommandHandler : IRequestHandler<UpdateEditoraCommand, int>
        {
            private readonly IScanDbContext _context;
            public UpdateEditoraCommandHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateEditoraCommand command, CancellationToken cancellationToken)
            {
                var editora = _context.Editoras.Where(a => a.IdEditora == command.IdEditora).FirstOrDefault();
                if (editora == null)
                {
                    return default;
                }
                else
                {
                    editora.NomeEditora = command.NomeEditora;
                    await _context.SaveChangesAsync();
                    return editora.IdEditora;
                }
            }
        }
    }
}
