using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TblUserVisite
    {
        [Key]
        public int id { get; set; }
        public string dateVisite { get; set; }
        public int CountUser { get; set; }
    }
}
