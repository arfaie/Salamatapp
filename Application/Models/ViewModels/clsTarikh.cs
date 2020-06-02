using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models.ViewModels
{
    public class clsTarikh
    {
        public string date()
        {
            DateTime dt = DateTime.Now;
            PersianCalendar pc = new PersianCalendar();
            string y, m, d;
            y = pc.GetYear(dt).ToString();
            m = pc.GetMonth(dt) < 10 ? "0" + pc.GetMonth(dt) : pc.GetMonth(dt).ToString();
            d = pc.GetDayOfMonth(dt) < 10 ? "0" + pc.GetDayOfMonth(dt) : pc.GetDayOfMonth(dt).ToString();

            return y + "/" + m + "/" + d;
        }
        public string time()
        {
            string Hour = DateTime.Now.Hour < 10 ? "0" + DateTime.Now.Hour : DateTime.Now.Hour.ToString();
            string min = DateTime.Now.Minute < 10 ? "0" + DateTime.Now.Minute : DateTime.Now.Minute.ToString();
            //string sec = DateTime.Now.Second < 10 ? "0" + DateTime.Now.Second : DateTime.Now.Second.ToString();
            return Hour + ":" + min;


        }
    }
}
