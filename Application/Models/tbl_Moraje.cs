using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class tbl_Moraje
    {
        [Key]
        public int idMoraje { get; set; }
        public string Moraje { get; set; }
    }
}
