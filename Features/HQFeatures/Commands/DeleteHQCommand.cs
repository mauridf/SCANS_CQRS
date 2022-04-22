using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCANS_CQRS.Context;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SCANS_CQRS.Features.HQFeatures.Commands
{
    public class DeleteHQCommand : IRequest<int>
    {
        public int IdHq { get; set; }
        public class DeleteHQCommandHandler : IRequestHandler<DeleteHQCommand, int>
        {
            private readonly IScanDbContext _context;
            public DeleteHQCommandHandler(IScanDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteHQCommand command, CancellationToken cancellationToken)
            {
                var hq = _context.HQs.Where(a => a.IdHQ == command.IdHq).FirstOrDefault();
                if (hq == null) return default;
                _context.HQs.Remove(hq);
                await _context.SaveChangesAsync();
                return hq.IdHQ;
            }
        }
    }
}
