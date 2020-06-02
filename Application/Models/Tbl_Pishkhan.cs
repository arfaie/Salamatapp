using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Tbl_Pishkhan
    {
        [Key]
        public int idPishkhan { get; set; }

        [Display(Name = "شهر")]
        [Required(ErrorMessage ="لطفا نام شهر را وارد نمایید")]
        public string city { get; set; }

        [Display(Name = "کد دفتر")]
        [Required(ErrorMessage = "لطفا کد دفتر را وارد نمایید")]
        public string code { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "لطفا آدرس را وارد نمایید")]
        public string address { get; set; }

        [Display(Name = "خیابان")]
        [Required(ErrorMessage = "لطفا خیابان را وارد نمایید")]
        public string street { get; set; }

        [Display(Name = "تلفن")]
        [Required(ErrorMessage = "لطفا تلفن را وارد نمایید")]
        public string tel { get; set; }

        public string lastUpdate { get; set; }
        public bool? flag { get; set; }

        [Display(Name = "X")]
        [Required(ErrorMessage = "لطفا X را وارد نمایید")]
        public string x { get; set; }

        [Display(Name = "Y")]
        [Required(ErrorMessage = "لطفا Y را وارد نمایید")]
        public string y { get; set; }

        [Display(Name = "نام مدیر")]
        [Required(ErrorMessage = "لطفا نام مدیر را وارد نمایید")]
        public string ManagerName { get; set; }
    }
}
