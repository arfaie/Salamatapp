using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class tbl_Institution
    {
        [Key]
        public int idIns { get; set; }

        [Display(Name = "کدموسسه")]
        [Required(ErrorMessage ="لطفا کد موسسه را وارد نمایید")]
        public int? Code { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا عنوان را وارد نمایید")]
        public string Title { get; set; }

        [Display(Name = "نوع موسسه")]
        [Required(ErrorMessage = "لطفا نوع موسسه را وارد نمایید")]
        public string Type { get; set; }

        [Display(Name = "شهر")]
        [Required(ErrorMessage = "لطفا شهر را وارد نمایید")]
        public string City { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "لطفا آدرس را وارد نمایید")]
        public string Adress { get; set; }

        [Display(Name = "تلفن")]
        [Required(ErrorMessage = "لطفا تلفن را وارد نمایید")]
        public string Tell { get; set; }

        [Display(Name = "تارخ بروزرسانی")]
        [Required(ErrorMessage = "لطفا تاریخ بروزرسانی را وارد نمایید")]
        public string UpdateDate { get; set; }
       
        public bool? flag { get; set; }

        [Display(Name = "X")]
        [Required(ErrorMessage = "لطفا X را وارد نمایید")]
        public string x { get; set; }

        [Display(Name = "Y")]
        [Required(ErrorMessage = "لطفا Y را وارد نمایید")]
        public string y { get; set; }
    }
}
