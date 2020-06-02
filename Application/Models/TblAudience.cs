using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TblAudience
    {
        [Key]
        public int idAudience { get; set; }
        public string nameAudience { get; set; }
    }
}
