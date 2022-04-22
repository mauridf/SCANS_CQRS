using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SCANS_CQRS.Entity
{
    public class PersEquipe
    {
        [Key]
        public int IdPersEquipe { get; set; }
        public string NomePersEquipe { get; set; }
        public string DscPersEquipe { get; set; }
        public List<HQ_PersEquipe> HQ_PersEquipe { get; set; }
    }
}
