using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ViewComplaint
    {
        public int idComplaint { get; set; }

        [Display(Name = "موبایل")]
        public string mobile { get; set; }

        [Display(Name = "آدرس")]
        public string Address { get; set; }
        public int idAudience { get; set; }

        [Display(Name = "نام")]
        public string fName { get; set; }

        [Display(Name = "نام خانوادگی")]
        public string lName { get; set; }

        [Display(Name = "کد بیمه")]
        public string CodeInsu { get; set; }

        [Display(Name = "کد ملی")]
        public string natcode { get; set; }
        public int idCashDeskInsurance { get; set; }

        [Display(Name = "نام بیمه")]
        public string insurerName { get; set; }

        [Display(Name = "واحد شکایت")]
        public string unitComplaint { get; set; }

        [Display(Name = "توضیحات")]
        public string des { get; set; }
        public byte[] img { get; set; }

        [Display(Name = "ساعت ارسال")]
        public string timeSend { get; set; }

        [Display(Name = "تاریخ ارسال")]
        public string dateSend { get; set; }
        public bool? readed { get; set; }

        [Display(Name = "صندوق بیمه")]
        public string namelCashDeskInsurance { get; set; }

        [Display(Name = "نوع مخاطب")]
        public string nameAudience { get; set; }

        [Display(Name ="شهر")]
        public string CityName { get; set; }
        public int idCity { get; set; }
    }
}
