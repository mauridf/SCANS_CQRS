using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCANS_CQRS.Context;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SCANS_CQRS.Features.EditoraFeatures.Commands
{
    public class DeleteEditoraCommand : IRequest<int>
    {
        public int IdEditora { get; set; }

        public class DeleteEditoraCommandHandler : IRequestHandler<DeleteEditoraCommand, int>
        {
            private readonly IScanDbContext _context;
            public DeleteEditoraCommandHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteEditoraCommand command, CancellationToken cancellationToken)
            {
                var editora = _context.Editoras.Where(a => a.IdEditora == command.IdEditora).FirstOrDefault();
                if (editora == null) return default;
                _context.Editoras.Remove(editora);
                await _context.SaveChangesAsync();
                return editora.IdEditora;
            }
        }
    }
}
