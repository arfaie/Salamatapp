using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class tbl_Reason
    {
        [Key]
        public int idReason { get; set; }
        public string ReasonText { get; set; }
    }
}
