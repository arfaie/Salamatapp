using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Tbl_Setadi
    {
        [Key]
        public int idSetadi { get; set; }

        [Display(Name = "نام اداره")]
        [Required(ErrorMessage ="لطفا نام اداره را وارد نمایید")]
        public string edare { get; set; }

        [Display(Name = "تلفن")]
        [Required(ErrorMessage = "لطفا تلفن را وارد نمایید")]
        public string tel { get; set; }

        public string lastUpdate { get; set; }
        public bool? flag { get; set; }
    }
}
