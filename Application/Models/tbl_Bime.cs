﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class tbl_Bime
    {
        [Key]
        public int idBime { get; set; }
        public string BimeType { get; set; }
    }
}
