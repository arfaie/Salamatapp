using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TblPersonal
    {
        [Key]
        public int idPerson { get; set; }

        [Display(Name = "کد ملی")]
        [Required(ErrorMessage ="لطفا کد ملی را وارد نمایید")]
        public string natCode { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا نام خانوادگی را وارد نمایید")]
        public string family { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا نام را وارد نمایید")]
        public string fname { get; set; }
    }
}
