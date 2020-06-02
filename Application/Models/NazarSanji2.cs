using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class NazarSanji2
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "شهرستان")]
        public string cityname { get; set; }

        [Display(Name = "جنسیت")]
        public string sex { get; set; }

        [Display(Name = "بیمارستان")]
        public string hostName { get; set; }

        [Display(Name = "مالکیت")]
        public string malekiyat { get; set; }

        [Display(Name = "مدت بستری")]
        public string modatBastari { get; set; }

        [Display(Name = "نام صندوق")]
        public string sandogName { get; set; }

        [Display(Name = "ارزیابی سوال 1")]
        public string ans1 { get; set; }

        [Display(Name = "ارزیابی سوال 2")]
        public string ans2 { get; set; }

        [Display(Name = "ارزیابی سوال 3")]
        public string ans3 { get; set; }

        [Display(Name = "ارزیابی سوال 4")]
        public string ans4 { get; set; }

        [Display(Name = "ارزیابی سوال 5")]
        public string ans5 { get; set; }

        [Display(Name = "ارزیابی سوال 6")]
        public string ans6 { get; set; }

        [Display(Name = "توضیحات")]
        public string tozihaot { get; set; }

        [Display(Name = "تاریخ")]
        public string ComDate { get; set; }

        [Display(Name = "زمان")]
        public string ComTime { get; set; }

        public bool? flag { get; set; }
    }
}
