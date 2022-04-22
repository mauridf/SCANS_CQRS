using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SCANS_CQRS.Entity
{
    public class HQ
    {
        [Key]
        public int IdHQ { get; set; }
        public string NomeHQ { get; set; }
        public string NumeroHQ { get; set; }
        public string VolumeHQ { get; set; }
        public string DscResumoHQ { get; set; }
        public int IdEditora { get; set; }
        public Editora Editora { get; set; }
        public int IdIdioma { get; set; }
        public Idioma Idioma { get; set; }
        public int IdTipoPublicacao { get; set; }
        public TipoPublicacao TipoPublicacao { get; set; }
        public List<HQ_PersEquipe> HQ_PersEquipe { get; set; }
    }
}
