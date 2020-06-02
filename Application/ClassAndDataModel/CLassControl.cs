using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Application.ClassAndDataModel
{
    public class CLassControl
    {
        public void SendMail(string email, string Subject, string body, bool IsBodyHtml)
        {
            //try
            {
                MailMessage mM = new MailMessage();
                mM.From = new MailAddress("jdasacir@yahoo.com");
                mM.To.Add(email);
                mM.Subject = Subject;
                mM.Body = body;
                mM.IsBodyHtml = IsBodyHtml;

                SmtpClient SmtpServer = new SmtpClient("smtp.mail.yahoo.com");
                SmtpServer.EnableSsl = true;
                SmtpServer.Credentials = new System.Net.NetworkCredential("jdasacir@yahoo.com", "123456789");

                SmtpServer.Port = 587;


                SmtpServer.Send(mM);
            }
            //catch (Exception ex)
            //{
            //}
        }
        public static string getTime()
        {
            System.Globalization.PersianCalendar persianDateTime = new System.Globalization.PersianCalendar();
            DateTime thisDate = DateTime.Now;
            string Hour = persianDateTime.GetHour(thisDate).ToString();
            if (Hour.Length == 1) Hour = "0" + Hour;
            string Minute = persianDateTime.GetMinute(thisDate).ToString();
            if (Minute.Length == 1) Minute = "0" + Minute;

            string TimeNow = Hour + ":" + Minute;
            return TimeNow;
        }
        public string getTime(DateTime thisDate)
        {
            System.Globalization.PersianCalendar persianDateTime = new System.Globalization.PersianCalendar();

            string Hour = persianDateTime.GetHour(thisDate).ToString();
            if (Hour.Length == 1) Hour = "0" + Hour;
            string Minute = persianDateTime.GetMinute(thisDate).ToString();
            if (Minute.Length == 1) Minute = "0" + Minute;

            string TimeNow = Hour + ":" + Minute;
            return TimeNow;
        }
        public string GetFarsiDate(int offsetday)
        {
            System.Globalization.PersianCalendar persianDateTime = new System.Globalization.PersianCalendar();

            DateTime thisDate = DateTime.Now.AddDays(-offsetday);

            string mon = persianDateTime.GetMonth(thisDate).ToString();
            if (mon.Length == 1) mon = "0" + mon;
            string day = persianDateTime.GetDayOfMonth(thisDate).ToString();
            if (day.Length == 1) day = "0" + day;
            string datenow = persianDateTime.GetYear(thisDate).ToString() + "/" + mon + "/" + day;
            return datenow;
        }
        public string GetFarsiDate()
        {
            System.Globalization.PersianCalendar persianDateTime = new System.Globalization.PersianCalendar();
            DateTime thisDate = DateTime.Now;
            string mon = persianDateTime.GetMonth(thisDate).ToString();
            if (mon.Length == 1) mon = "0" + mon;
            string day = persianDateTime.GetDayOfMonth(thisDate).ToString();
            if (day.Length == 1) day = "0" + day;
            string datenow = persianDateTime.GetYear(thisDate).ToString() + "/" + mon + "/" + day;
            return datenow;
        }
        public string GetFarsiDate(DateTime thisDate)
        {
            System.Globalization.PersianCalendar persianDateTime = new System.Globalization.PersianCalendar();

            string mon = persianDateTime.GetMonth(thisDate).ToString();
            if (mon.Length == 1) mon = "0" + mon;
            string day = persianDateTime.GetDayOfMonth(thisDate).ToString();
            if (day.Length == 1) day = "0" + day;
            string datenow = persianDateTime.GetYear(thisDate).ToString() + "/" + mon + "/" + day;
            return datenow;
        }
        public List<System.IO.FileInfo> GetFilesFromFolderImage(string folderName)
        {

            DirectoryInfo directoryInfo = new DirectoryInfo(folderName);

            string extension = "*.*";

            //   string internalExtension = string.Concat("*.", extension);



            FileInfo[] fileInfo = directoryInfo.GetFiles(extension, SearchOption.AllDirectories);
            string[] extantionFormat = new string[] { ".jpg", ".bmp", ".png", ".gif" };

            List<System.IO.FileInfo> list2 = (from extItem in extantionFormat
                                              from fileItem in fileInfo
                                              where extItem.ToLower().Equals
                                              (fileItem.Extension.ToLower())
                                              select fileItem).ToList();
            return list2;

        }
        public FileInfo[] GetFilesFromFolderFile(string folderName)
        {

            DirectoryInfo directoryInfo = new DirectoryInfo(folderName);

            string extension = "*.*";

            //   string internalExtension = string.Concat("*.", extension);



            FileInfo[] fileInfo = directoryInfo.GetFiles(extension, SearchOption.AllDirectories);

            return fileInfo;

        }
        public static string GetLastUpdate()
        {
            string time;
            string date;
            time = DateTime.Now.ToString("HHmm");
            date = DateTime.Now.ToString("yyyyMMdd");
            return date + time;
        }
    }
}
