using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TblTel
    {
        [Key]
        public int id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string tel { get; set; }
    }
}
