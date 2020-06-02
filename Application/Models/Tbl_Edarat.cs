using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Tbl_Edarat
    {
        [Key]
        public int idOffice { get; set; }

        [Display(Name = "شهرستان")]
        [Required(ErrorMessage = "لطفا شهرستان را وارد نمایید")]
        public string city { get; set; }

        [Display(Name = "رئیس اداره")]
        [Required(ErrorMessage = "لطفا رئیس اداره را وارد نمایید")]
        public string admin { get; set; }

        [Display(Name = "تلفن")]
        [Required(ErrorMessage = "لطفا تلفن را وارد نمایید")]
        public string Tell { get; set; }

        [Display(Name = "فکس")]
        [Required(ErrorMessage = "لطفا فکس را وارد نمایید")]
        public string Fax { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "لطفا آدرس را وارد نمایید")]
        public string adress { get; set; }
        
        public string lastUpdate { get; set; }
        public bool? flag { get; set; }

        [Display(Name = "X")]
        [Required(ErrorMessage = "لطفا X را وارد نمایید")]
        public string x { get; set; }

        [Display(Name = "Y")]
        [Required(ErrorMessage = "لطفا Y را وارد نمایید")]
        public string y { get; set; }
    }
}
