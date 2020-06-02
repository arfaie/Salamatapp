﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Application.Models.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا نام کاربری را وارد نمایید")]
        public string Username { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "رمز را وارد")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "حداق طول رمز عبور 6 کاراکتر و حداکثر 20 کاراکتر می باشد")]
        public string Password { get; set; }

        [Display(Name = "تکرار رمز")]
        [Required(ErrorMessage = "تکرار رمز را وارد")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "رمز عبور با تکرار آن یکسان نیست!")]
        public string ConfirmPassword { get; set; }

        //[Display(Name ="نام و نام خانوادگی")]
        //[Required(ErrorMessage ="نام را وارد کنید")]
        //public string FullName { get; set; }

        [Display(Name = "نام ")]
        [Required(ErrorMessage = "نام را وارد کنید")]
        public string FirstName { get; set; }

        [Display(Name = " نام خانوادگی")]
        [Required(ErrorMessage = "نام خانوادگی را وارد کنید")]
        public string LastName { get; set; }

        [Display(Name = "تلفن")]
        [Required(ErrorMessage = "تلفن را وارد کنید")]
        public string PhoneNumber { get; set; }



        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "ایمیل را وارد نمایید")]
        [DataType(DataType.EmailAddress, ErrorMessage = "صحیح")]
        public string Email { get; set; }

        //////////////////////////////////////////////////////////////For Show Role In DropDown
        public List<SelectListItem> ApplicationRoles { get; set; }

        [Display(Name = "نقش")]
        public string ApplicationRoleId { get; set; }
    }
}
