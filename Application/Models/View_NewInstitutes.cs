using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class View_NewInstitutes
    {
        public int idInstitues { get; set; }

        [Display(Name = "کدموسسه")]
        [Required(ErrorMessage = "لطفا کد موسسه را وارد نمایید")]
        public int? codeOrgan { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا نام را وارد نمایید")]
        public string nameOrgan { get; set; }

        [Display(Name = "نام ارگان اصلی")]
        [Required(ErrorMessage = "لطفا نام ارگان اصلی را وارد نمایید")]
        public string nameOrganMain { get; set; }

        [Display(Name = "بیمارستان")]
        [Required(ErrorMessage = "لطفا بیمارستان را وارد نمایید")]
        public string hos { get; set; }
        public int? idINSTITUTE_TYPE { get; set; }
        public int? idowner { get; set; }
        public int? idCity { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "لطفا آدرس را وارد نمایید")]
        public string ADDRESS { get; set; }
        public string ZIP { get; set; }

        [Display(Name = "تلفن")]
        [Required(ErrorMessage = "لطفا تلفن را وارد نمایید")]
        public string TEL { get; set; }

        [Display(Name = "فاکس")]
        [Required(ErrorMessage = "لطفا فاکس را وارد نمایید")]
        public string fax { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا ایمیل را وارد نمایید")]
        public string email { get; set; }

        [Display(Name = "همراه")]
        [Required(ErrorMessage = "لطفا همراه را وارد نمایید")]
        public string mobile { get; set; }
        public string lastUpdate { get; set; }
        public bool? flag { get; set; }
        public string OwnerName { get; set; }

        [Display(Name = "شهرستان")]
        [Required(ErrorMessage = "لطفا شهرستان را وارد نمایید")]
        public string CityName { get; set; }

        [Display(Name = "نوع موسسه")]
        [Required(ErrorMessage = "لطفا نوع موسسه را وارد نمایید")]
        public string INSTITUTE_TYPE { get; set; }
    }
}
