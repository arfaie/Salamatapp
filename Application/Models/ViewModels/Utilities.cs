using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace Application.Models.ViewModels
{
    public static class Utilities
    {
        public static string GetLastUpdate(this string str)
        {
            try
            {
                string time;
                string date;
                time = DateTime.Now.ToString("HHmm");
                date = DateTime.Now.ToString("yyyyMMdd");
                return date + time;
            }
            catch
            {
                return null;
            }

        }
        public static int GetPersianDate(this int dt)
        {
            DateTime Today = DateTime.Today;
            PersianCalendar pc = new PersianCalendar();
            string year = pc.GetYear(Today).ToString();
            string month = pc.GetMonth(Today).ToString();
            if (month.Length < 2)
            {
                month = "0" + month;
            }
            string day = pc.GetDayOfMonth(Today).ToString();
            if (day.Length < 2)
            {
                day = "0" + day;
            }

            //return new DateTime(month, day, year, 0, 0, 0);
            return int.Parse(year + month + day);
        }
        public static string ToSlashDate(this string dt)
        {
            if (dt.ToString().Length >= 8)
            {
                string slashDate = "";

                string intDate = dt.ToString();
                slashDate = intDate.Substring(0, 4) + "/";
                slashDate += intDate.Substring(4, 2) + "/";
                slashDate += intDate.Substring(6, 2);
                return slashDate;
            }
            else
                return "0";

        }
    }
}
