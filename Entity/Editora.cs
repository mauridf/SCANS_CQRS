﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SCANS_CQRS.Entity
{
    public class Editora
    {
        [Key]
        public int IdEditora { get; set; }
        public string NomeEditora { get; set; }
        public List<HQ> HQs { get; set; }
    }
}
