using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models.Helpers
{
    public static class Helper
    {
        public static string toShamsi(this DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();
            var calendar = new PersianCalendar();
            var persianDate = new DateTime(calendar.GetYear(date), calendar.GetMonth(date), calendar.GetDayOfMonth(date));
            var result = string.Format("{0}/{1}/{2}", pc.GetYear(date), pc.GetMonth(date), pc.GetDayOfMonth(date));
            return result;
        }
    }
}
