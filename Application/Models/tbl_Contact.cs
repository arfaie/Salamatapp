using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class tbl_Contact
    {
        [Key]
        public int idContact { get; set; }

        [Display(Name = "پست الکترونیکی")]
        [Required(ErrorMessage ="لطفا پست الکترونیکی را وارد نمایید")]
        public string mail { get; set; }

        [Display(Name = "فکس")]
        [Required(ErrorMessage = "لطفا فکس را وارد نمایید")]
        public string fax { get; set; }

        [Display(Name = "کد پستی")]
        [Required(ErrorMessage = "لطفا کد پستی را وارد نمایید")]
        public string postalCode { get; set; }

        [Display(Name = "تلفن")]
        [Required(ErrorMessage = "لطفا تلفن را وارد نمایید")]
        public string tel { get; set; }

        [Display(Name = "وبسایت")]
        [Required(ErrorMessage = "لطفا وبسایت را وارد نمایید")]
        public string website { get; set; }

        [Display(Name = "صندوق پستی")]
        [Required(ErrorMessage = "لطفا صندوق پستی را وارد نمایید")]
        public string postBox { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "لطفا آدرس را وارد نمایید")]
        public string adress { get; set; }

        [Display(Name = "تلفن گویا")]
        [Required(ErrorMessage = "لطفا تلفن گویا را وارد نمایید")]
        public string TelSmart { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا توضیحات را وارد نمایید")]
        public string Des { get; set; }

        [Display(Name = "X")]
        [Required(ErrorMessage = "لطفا X را وارد نمایید")]
        public string x { get; set; }

        [Display(Name = "Y")]
        [Required(ErrorMessage = "لطفا Y را وارد نمایید")]
        public string y { get; set; }
      
        public string lastUpdate { get; set; }
    }
}
