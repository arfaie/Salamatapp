﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TblOwner_
    {
        [Key]
        public int idOwner { get; set; }
        public string OwnerName { get; set; }
        public string lastUpdate { get; set; }
        public bool? flag { get; set; }
    }
}
