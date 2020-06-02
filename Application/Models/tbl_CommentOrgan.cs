    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class tbl_CommentOrgan
    {
        [Key]
        public int idComment { get; set; }

        [Display(Name = "متن")]
        [Required(ErrorMessage ="لطفا متن را وارد نمایید")]
        public string CommentText { get; set; }

        [Display(Name = "زمان")]
        [Required(ErrorMessage = "لطفا زمان را وارد نمایید")]
        public string ComTime { get; set; }
        public bool flag { get; set; }

        [Display(Name = "تاریخ")]
        [Required(ErrorMessage = "لطفا تاریخ را وارد نمایید")]
        public string ComDate { get; set; }

        [Display(Name ="نام موسسه")]
        [Required(ErrorMessage = "لطفا نام موسسه را وارد نمایید")]
        public string OrganName { get; set; }

        [Display(Name = "کد موسسه")]
        [Required(ErrorMessage = "لطفا کد موسسه را وارد نمایید")]
        public string OrganCode { get; set; }
    }
}
