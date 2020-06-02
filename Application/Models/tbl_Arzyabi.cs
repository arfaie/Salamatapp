using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class tbl_Arzyabi
    {
        [Key]
        public int idArzyabi { get; set; }
        public string Arzyabi { get; set; }
    }
}
