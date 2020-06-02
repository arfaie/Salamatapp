using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TblReshteh_
    {
        [Key]
        public int idReshteh { get; set; }
        public string reshtehName { get; set; }
        public string lastUpdate { get; set; }
        public bool? flag { get; set; }
    }
}
