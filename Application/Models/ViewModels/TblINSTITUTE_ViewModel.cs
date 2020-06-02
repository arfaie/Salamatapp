using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models.ViewModels
{
    public class TblINSTITUTE_ViewModel
    {
        [Key]
        public int idInstitues { get; set; }

        [Display(Name = "کدموسسه")]
        [Required(ErrorMessage = "لطفا کد موسسه را وارد نمایید")]
        public int? codeOrgan { get; set; }

        [Display(Name = "نام ارگان")]
        [Required(ErrorMessage = "لطفا نام ارگان را وارد نمایید")]
        public string nameOrgan { get; set; }

        [Display(Name = "نام ارگان اصلی")]
        [Required(ErrorMessage = "لطفا نام ارگان اصلی را وارد نمایید")]
        public string nameOrganMain { get; set; }

        [Display(Name = "بیمارستان")]
        [Required(ErrorMessage = "لطفا بیمارستان را وارد نمایید")]
        public string hos { get; set; }
      
        [Display(Name = "آدرس")]
        
        public string ADDRESS { get; set; }

        [Display(Name = "تلفن")]
        
        public string TEL { get; set; }
        public string ZIP { get; set; }

        [Display(Name = "فکس")]
        
        public string fax { get; set; }

        [Display(Name = "ایمیل")]
       
        public string email { get; set; }

        [Display(Name = "موبایل")]
       
        public string mobile { get; set; }
        public string lastUpdate { get; set; }
        public bool? flag { get; set; }

        /////////////////////////////////////////////////////

        [Display(Name = "شهر")]
        public int? idCity { get; set; }

        public List<SelectListItem> Cites { get; set; }

        [Display(Name = "صاحب")]
        public int? idowner { get; set; }

        public List<SelectListItem> Owners { get; set; }

        [Display(Name = "نوع موسسه")]
        public int? idINSTITUTE_TYPE { get; set; }

        public List<SelectListItem> Institute_Types { get; set; }

    }
}
