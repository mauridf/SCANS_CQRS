using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SCANS_CQRS.Entity
{
    public class HQ_PersEquipe
    {
        [Key]
        public int IdHQPersEquipe { get; set; }
        public int IdPersEquipe { get; set; }
        public PersEquipe PersEquipe { get; set; }
        public int IdHQ { get; set; }
        public HQ HQ { get; set; }
    }
}
