using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class tbl_Informing
    {
        [Key]
        public int idInfo { get; set; }

        [Display(Name = "متن اطلاعیه")]
        [Required(ErrorMessage ="لطفا متن اطلاعیه را وارد نمایید")]
        public string infoDes { get; set; }

        [Display(Name = "تاریخ و ساعت")]
        public string InfoDateTime { get; set; }
        public string lastUpdate { get; set; }
        public string imagename { get; set; }
        public bool? privatePer { get; set; }
        public bool? flag { get; set; }


    }
}
