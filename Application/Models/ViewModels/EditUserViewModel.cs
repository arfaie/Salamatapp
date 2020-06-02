using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Application.Models.ViewModels
{
    public class EditUserViewModel
    {
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "لطفا نام را وارد نمایید")]
        public string FirstName { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "لطفا نام خانوادگی را وارد نمایید")]
        public string LastName { get; set; }



        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا")]
        //[DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "ایمیل معتبر نیست")]
        public string Email { get; set; }

        public List<SelectListItem> ApplicationRoles { get; set; }

        [Display(Name = "نقش")]
        public string ApplicationRoleId { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا نام کاربری را وارد نمایید")]
        public string Username { get; set; }
    }
}
