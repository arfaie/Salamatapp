using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class tbl_State
    {
        
        [Key]
        public int idState { get; set; }
        public string StateName { get; set; }

    }
}
