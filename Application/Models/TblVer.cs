using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TblVer
    {
        [Key]
        public int IdVer { get; set; }
        public int verCode { get; set; }
        public string DateUpdate { get; set; }
    }
}
