using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TblINSTITUTE_TYPE_
    {
        [Key]
        public int idINSTITUTE_TYPE { get; set; }
        public string INSTITUTE_TYPE { get; set; }
        public string lastUpdate { get; set; }
        public bool? flag { get; set; }
    }
}
