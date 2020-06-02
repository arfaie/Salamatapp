using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class tbl_sex
    {
        [Key]
        public bool idSex { get; set; }
        public string sexName { get; set; }
    }
}
