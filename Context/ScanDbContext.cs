using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCANS_CQRS.Entity;

namespace SCANS_CQRS.Context
{
    public class ScanDbContext : DbContext
    {
        public ScanDbContext(DbContextOptions<ScanDbContext> options) : base(options)
        { }

        public DbSet<Editora> Editoras { get; set; }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
