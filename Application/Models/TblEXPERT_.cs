﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TblEXPERT_
    {
        [Key]
        public int idExpert { get; set; }
        public string ExpertName { get; set; }
        public string lastUpdate { get; set; }
        public bool? flag { get; set; }
    }
}
