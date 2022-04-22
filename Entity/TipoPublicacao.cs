using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SCANS_CQRS.Entity
{
    public class TipoPublicacao
    {
        [Key]
        public int IdTipoPublicacao { get; set; }
        public string NomeTipoPublicacao { get; set; }
        public List<HQ> HQs { get; set; }
    }
}
