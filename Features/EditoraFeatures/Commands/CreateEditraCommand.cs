using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SCANS_CQRS.Context;
using SCANS_CQRS.Entity;

namespace SCANS_CQRS.Features.EditoraFeatures.Commands
{
    public class CreateEditraCommand : IRequest<int>
    {
        public int IdEditora { get; set; }
        public string NomeEditora { get; set; }

        public class CreateEditraCommandHandler : IRequestHandler<CreateEditraCommand, int>
        {
            private readonly IScanDbContext _context;
            public CreateEditraCommandHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateEditraCommand command, CancellationToken cancellationToken)
            {
                var editora = new Editora();
                editora.IdEditora = command.IdEditora;
                editora.NomeEditora = command.NomeEditora;
                _context.Editoras.Add(editora);
                await _context.SaveChangesAsync();
                return editora.IdEditora;
            }
        }
    }
}
