using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models.ViewModels
{
    public class CommentListViewModel
    {
        public int idComment { get; set; }

        [Display(Name = "سن")]
        public int age { get; set; }

        [Display(Name = "ارزیابی سوال 1")]
        public string IdQ1 { get; set; }

        [Display(Name = "ارزیابی سوال 2")]
        public string IdQ2 { get; set; }

        [Display(Name = "ارزیابی سوال 3")]
        public string IdQ3 { get; set; }

        [Display(Name = "ارزیابی سوال 4")]
        public string IdQ4 { get; set; }

        [Display(Name = "ارزیابی سوال 5")]
        public string IdQ5 { get; set; }

        [Display(Name = "ارزیابی سوال 6")]
        public string IdQ6 { get; set; }

        [Display(Name = "متن")]
        public string CommentText { get; set; }

        [Display(Name = "تاریخ و زمان")]
        public string ComTime { get; set; }

        public bool flag { get; set; }

        public string ComDate { get; set; }

        [Display(Name = "مناسب ترین برخورد")]
        public string FirstPerson { get; set; }

        [Display(Name = "برخورد نامناسب")]
        public string SecondPeson { get; set; }

        public int idState { get; set; }
       
        public bool idSex { get; set; }
       
        public int idEducation { get; set; }
      
        public int idBime { get; set; }
       
        public int idMoraje { get; set; }
       
        public int idReason { get; set; }

        [Display(Name = "شهرستان")]
        public string StateName { get; set; }

        [Display(Name = "جنسیت")]
        public string sexName { get; set; }

        [Display(Name = "تحصیلات")]
        public string EduName { get; set; }

        [Display(Name = "نوع بیمه")]
        public string BimeType { get; set; }

        [Display(Name = "تعداد مراجعه")]
        public string Moraje { get; set; }

        [Display(Name = "علت مراجعه")]
        public string ReasonText { get; set; }

    }
}
