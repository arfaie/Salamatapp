using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class tbl_Education2
    {
        [Key]
        public int idEdu { get; set; }
        public string EduName { get; set; }
    }
}
