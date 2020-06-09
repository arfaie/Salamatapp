using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Helpers.OptionEnums;
using Application.Models;
using Application.Models.NavbarModels;
using Application.Models.ViewModels;
using Application.Net;
using Application.Net.OptionEnums;
using FastMember;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Application.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ComplaintController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComplaintController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HttpContext.Session.SetString("Fromdate1c", "null");
            HttpContext.Session.SetString("Todate1c", "null");

            ClsNavbar clsNavbar = new ClsNavbar(_context);
            ComplaintNavbar complaintNavbar = new ComplaintNavbar();

            var select = await _context.ViewComplaint.OrderByDescending(v => v.idComplaint).ToListAsync();

            complaintNavbar.complaints = select;
            complaintNavbar.CommentListNavbar = await clsNavbar.Comment();
            complaintNavbar.ComplaintsListNavbar = await clsNavbar.Complaint();
            complaintNavbar.commentcount = complaintNavbar.CommentListNavbar.Count;
            complaintNavbar.complaintcount = complaintNavbar.ComplaintsListNavbar.Count;


            return View(complaintNavbar);
        }

        public async Task<IActionResult> complaintSearch(string fromdate1, string todate1)
        {
            ClsNavbar clsNavbar = new ClsNavbar(_context);
            ComplaintNavbar complaintNavbar = new ComplaintNavbar();

            HttpContext.Session.SetString("Fromdate1c", "null");
            HttpContext.Session.SetString("Todate1c", "null");

            var select = await _context.ViewComplaint.OrderByDescending(x => x.idComplaint).ToListAsync();

            if (fromdate1 != null && todate1 == null)
            {
                HttpContext.Session.SetString("Fromdate1c", fromdate1);
                select = select.Where(m => m.dateSend.CompareTo(fromdate1) >= 0).ToList();
            }

            if (todate1 != null && fromdate1 == null)
            {
                HttpContext.Session.SetString("Todate1c", todate1);
                select = select.Where(m => m.dateSend.CompareTo(todate1) <= 0).ToList();
            }

            if (fromdate1 != null && todate1 != null)
            {

                HttpContext.Session.SetString("Fromdate1c", fromdate1);
                HttpContext.Session.SetString("Todate1c", todate1);
                select = select.Where(m => m.dateSend.CompareTo(fromdate1) >= 0 && m.dateSend.CompareTo(todate1) <= 0)
                    .ToList();

            }

            complaintNavbar.complaints = select;
            complaintNavbar.CommentListNavbar = await clsNavbar.Comment();
            complaintNavbar.ComplaintsListNavbar = await clsNavbar.Complaint();
            complaintNavbar.commentcount = complaintNavbar.CommentListNavbar.Count;
            complaintNavbar.complaintcount = complaintNavbar.ComplaintsListNavbar.Count;

            return View("Index", complaintNavbar);
        }

        public IActionResult exportExcel()
        {



            byte[] filecontents;

            using (var pakage = new ExcelPackage())
            {
                var worksheet = pakage.Workbook.Worksheets.Add("Sheet1");


                worksheet.Cells[1, 1].Value = "کد";
                worksheet.Cells[1, 1].Style.Font.Size = 12;
                worksheet.Cells[1, 1].Style.Font.Bold = true;
                worksheet.Cells[1, 1].Style.Border.Top.Style = ExcelBorderStyle.Hair;


                worksheet.Cells[1, 2].Value = "موبایل";
                worksheet.Cells[1, 2].Style.Font.Size = 12;
                worksheet.Cells[1, 2].Style.Font.Bold = true;
                worksheet.Cells[1, 2].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 3].Value = "آدرس";
                worksheet.Cells[1, 3].Style.Font.Size = 12;
                worksheet.Cells[1, 3].Style.Font.Bold = true;
                worksheet.Cells[1, 3].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 4].Value = "نام";
                worksheet.Cells[1, 4].Style.Font.Size = 12;
                worksheet.Cells[1, 4].Style.Font.Bold = true;
                worksheet.Cells[1, 4].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 5].Value = "نام خانوادگی";
                worksheet.Cells[1, 5].Style.Font.Size = 12;
                worksheet.Cells[1, 5].Style.Font.Bold = true;
                worksheet.Cells[1, 5].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 6].Value = "کد بیمه";
                worksheet.Cells[1, 6].Style.Font.Size = 12;
                worksheet.Cells[1, 6].Style.Font.Bold = true;
                worksheet.Cells[1, 6].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 7].Value = "کد ملی";
                worksheet.Cells[1, 7].Style.Font.Size = 12;
                worksheet.Cells[1, 7].Style.Font.Bold = true;
                worksheet.Cells[1, 7].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 8].Value = "نام بیمه";
                worksheet.Cells[1, 8].Style.Font.Size = 12;
                worksheet.Cells[1, 8].Style.Font.Bold = true;
                worksheet.Cells[1, 8].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 9].Value = "واحد شکایت";
                worksheet.Cells[1, 9].Style.Font.Size = 12;
                worksheet.Cells[1, 9].Style.Font.Bold = true;
                worksheet.Cells[1, 9].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 10].Value = "توضیحات";
                worksheet.Cells[1, 10].Style.Font.Size = 12;
                worksheet.Cells[1, 10].Style.Font.Bold = true;
                worksheet.Cells[1, 10].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 11].Value = "ساعت ارسال";
                worksheet.Cells[1, 11].Style.Font.Size = 12;
                worksheet.Cells[1, 11].Style.Font.Bold = true;
                worksheet.Cells[1, 11].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 12].Value = "تاریخ ارسال";
                worksheet.Cells[1, 12].Style.Font.Size = 12;
                worksheet.Cells[1, 12].Style.Font.Bold = true;
                worksheet.Cells[1, 12].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 13].Value = "صندوق بیمه";
                worksheet.Cells[1, 13].Style.Font.Size = 12;
                worksheet.Cells[1, 13].Style.Font.Bold = true;
                worksheet.Cells[1, 13].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 14].Value = "نوع مخاطب";
                worksheet.Cells[1, 14].Style.Font.Size = 12;
                worksheet.Cells[1, 14].Style.Font.Bold = true;
                worksheet.Cells[1, 14].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 15].Value = "شهر";
                worksheet.Cells[1, 15].Style.Font.Size = 12;
                worksheet.Cells[1, 15].Style.Font.Bold = true;
                worksheet.Cells[1, 15].Style.Border.Top.Style = ExcelBorderStyle.Hair;




                var select = _context.ViewComplaint.OrderByDescending(v => v.idComplaint).ToList();

                string fromdate1 = HttpContext.Session.GetString("Fromdate1c");
                string todate1 = HttpContext.Session.GetString("Todate1c");

                if (fromdate1 != "null" && todate1 == "null")
                {
                    select = select.Where(m => m.dateSend.CompareTo(fromdate1) >= 0).ToList();

                }
                else if (todate1 != "null" && fromdate1 == "null")
                {
                    select = select.Where(m => m.dateSend.CompareTo(todate1) <= 0).ToList();
                }
                else if (fromdate1 != "null" && todate1 != "null")
                {

                    select = select.Where(m => m.dateSend.CompareTo(fromdate1) >= 0 && m.dateSend.CompareTo(todate1) <= 0)
                        .ToList();
                }


                int i = 2;
                foreach (var item in select)
                {
                    worksheet.Cells[i, 1].Value = item.idComplaint;
                    worksheet.Cells[i, 1].Style.Font.Size = 12;
                    worksheet.Cells[i, 1].Style.Border.Top.Style = ExcelBorderStyle.Hair;


                    worksheet.Cells[i, 2].Value = item.mobile;
                    worksheet.Cells[i, 2].Style.Font.Size = 12;
                    worksheet.Cells[i, 2].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 3].Value = item.Address;
                    worksheet.Cells[i, 3].Style.Font.Size = 12;
                    worksheet.Cells[i, 3].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 4].Value = item.fName;
                    worksheet.Cells[i, 4].Style.Font.Size = 12;
                    worksheet.Cells[i, 4].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 5].Value = item.lName;
                    worksheet.Cells[i, 5].Style.Font.Size = 12;
                    worksheet.Cells[i, 5].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 6].Value = item.CodeInsu;
                    worksheet.Cells[i, 6].Style.Font.Size = 12;
                    worksheet.Cells[i, 6].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 7].Value = item.natcode;
                    worksheet.Cells[i, 7].Style.Font.Size = 12;
                    worksheet.Cells[i, 7].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 8].Value = item.insurerName;
                    worksheet.Cells[i, 8].Style.Font.Size = 12;
                    worksheet.Cells[i, 8].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 9].Value = item.unitComplaint;
                    worksheet.Cells[i, 9].Style.Font.Size = 12;
                    worksheet.Cells[i, 9].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 10].Value = item.des;
                    worksheet.Cells[i, 10].Style.Font.Size = 12;
                    worksheet.Cells[i, 10].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 11].Value = item.timeSend;
                    worksheet.Cells[i, 11].Style.Font.Size = 12;
                    worksheet.Cells[i, 11].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 12].Value = item.dateSend;
                    worksheet.Cells[i, 12].Style.Font.Size = 12;
                    worksheet.Cells[i, 12].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 13].Value = item.namelCashDeskInsurance;
                    worksheet.Cells[i, 13].Style.Font.Size = 12;
                    worksheet.Cells[i, 13].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 14].Value = item.nameAudience;
                    worksheet.Cells[i, 14].Style.Font.Size = 12;
                    worksheet.Cells[i, 14].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 15].Value = item.CityName;
                    worksheet.Cells[i, 15].Style.Font.Size = 12;
                    worksheet.Cells[i, 15].Style.Border.Top.Style = ExcelBorderStyle.Hair;



                    i++;

                }

                filecontents = pakage.GetAsByteArray();

            }
            if (filecontents == null || filecontents.Length == 0)
            {
                return NotFound();
            }

            return File(
                fileContents: filecontents,
                contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileDownloadName: DateTime.Now.Date.ToShortDateString() + ".xlsx"
            );


        }
        public IActionResult isRead(int id)
        {
            var select = _context.TblComplaint.Where(x => x.idComplaint == id).FirstOrDefault();
            select.readed = true;
            _context.TblComplaint.Update(select);
            _context.SaveChangesAsync();
            TempData["Notif"] = Notification.ShowNotif(MessageType.Edit, type: ToastType.green);
            return RedirectToAction("index");

        }

    }
}