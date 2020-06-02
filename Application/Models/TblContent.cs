using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class TblContent
    {
        [Key]
        public int ContentId { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage ="لطفا عنوان را وارد نمایید")]
        public string contentTitel { get; set; }

        [Display(Name = "متن")]
        [Required(ErrorMessage = "لطفا متن را وارد نمایید")]
        public string contentText { get; set; }

        [Display(Name = "تاریخ")]
        public string ContenteDate { get; set; }
        public bool? flag { get; set; }
    }
}
