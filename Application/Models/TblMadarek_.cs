using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TblMadarek_
    {
        [Key]
        public int idMadarek { get; set; }
        public string MadarekName { get; set; }
        public string lastUpdate { get; set; }
        public bool? flag { get; set; }
    }
}

