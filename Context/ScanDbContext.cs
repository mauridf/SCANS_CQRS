using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SCANS_CQRS.Entity;

namespace SCANS_CQRS.Context
{
    public class ScanDbContext : DbContext, IScanDbContext
    {
        public ScanDbContext(DbContextOptions<ScanDbContext> options) : base(options)
        { }

        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }
        public DbSet<PersEquipe> PersEquipes { get; set; }
        public DbSet<TipoPublicacao> TipoPublicacoes { get; set; }
        public DbSet<HQ> HQs { get; set; }
        public DbSet<HQ_PersEquipe> HQ_PersEquipes { get; set; }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
