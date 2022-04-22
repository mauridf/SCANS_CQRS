using SCANS_CQRS.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SCANS_CQRS.Context
{
    public interface IScanDbContext
    {
        DbSet<Editora> Editoras { get; set; }
        DbSet<Idioma> Idiomas { get; set; }
        DbSet<PersEquipe> PersEquipes { get; set; }
        DbSet<TipoPublicacao> TipoPublicacoes { get; set; }
        DbSet<HQ> HQs { get; set; }
        DbSet<HQ_PersEquipe> HQ_PersEquipes { get; set; }

        Task<int> SaveChangesAsync();
    }
}
