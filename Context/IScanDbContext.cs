using SCANS_CQRS.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SCANS_CQRS.Context
{
    interface IScanDbContext
    {
        DbSet<Editora> Editoras { get; set; }

        Task<int> SaveChangesAsync();
    }
}
