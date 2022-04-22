using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SCANS_CQRS.Entity
{
    public class Idioma
    {
        [Key]
        public int IdIdioma { get; set; }
        public string NomeIdioma { get; set; }
        public List<HQ> HQs { get; set; }
    }
}
