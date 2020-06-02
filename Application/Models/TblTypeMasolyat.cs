using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TblTypeMasolyat
    {
        
        public string TypeMasolyat { get; set; }

        [Key]
        public int TypeMasolyatID { get; set; }
    }
}
