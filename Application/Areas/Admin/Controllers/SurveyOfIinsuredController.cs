using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Helpers.OptionEnums;
using Application.Models;
using Application.Models.NavbarModels;
using Application.Models.ViewModels;
using Application.Net;
using Application.Net.OptionEnums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Application.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SurveyOfIinsuredController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public SurveyOfIinsuredController(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public async Task<IActionResult> Index()
        {
            ClsNavbar clsNavbar = new ClsNavbar(_context);
            SurveyOfIinsuredNavbar surveyOfIinsuredNavbar = new SurveyOfIinsuredNavbar();

            var select = await _context.SurveyOfIinsureds.Include(s => s.TblCity).Include(s => s.TblBime)
                .ToListAsync();

            surveyOfIinsuredNavbar.SurveyOfIinsureds = select;
            surveyOfIinsuredNavbar.CommentListNavbar = await clsNavbar.Comment();
            surveyOfIinsuredNavbar.ComplaintsListNavbar = await clsNavbar.Complaint();
            surveyOfIinsuredNavbar.commentcount = surveyOfIinsuredNavbar.CommentListNavbar.Count;
            surveyOfIinsuredNavbar.complaintcount = surveyOfIinsuredNavbar.ComplaintsListNavbar.Count;

            return View(surveyOfIinsuredNavbar);
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddEdit(int id)
        {
            var model = await _context.SurveyOfIinsureds.FirstOrDefaultAsync(c => c.Id == id);

            ViewBag.City = new SelectList(await _context.TblCity_.ToListAsync(), "idCity", "CityName");

            ViewBag.Bime = new SelectList(await _context.tbl_Bime.ToListAsync(), "idBime", "BimeType");

            if (model != null)
            {
                return PartialView("AddEdit", model);
            }

            return PartialView("AddEdit", new SurveyOfIinsured());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEdit(string id, SurveyOfIinsured model, string redirectUrl)
        {
            if (ModelState.IsValid)
            {
                if (String.IsNullOrWhiteSpace(id))
                {
                    await _context.SurveyOfIinsureds.AddAsync(model);
                    await _context.SaveChangesAsync();

                    TempData["Notification"] = Notification.ShowNotif(MessageType.Add, ToastType.green);
                    return PartialView("_Succefullyresponse", redirectUrl);
                }

                _context.SurveyOfIinsureds.Update(model);
                await _context.SaveChangesAsync();

                TempData["Notification"] = Notification.ShowNotif(MessageType.Edit, ToastType.blue);
                return PartialView("_Succefullyresponse", redirectUrl);
            }

            return PartialView("AddEdit", model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var surveyofiinsured = new SurveyOfIinsured();
            if (Id != 0)
            {
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    surveyofiinsured = await _context.SurveyOfIinsureds.FirstOrDefaultAsync(s => s.Id == Id);
                    if (surveyofiinsured == null)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return PartialView("Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, string redirecturl)
        {
            if (ModelState.IsValid)
            {

                var model = await _context.SurveyOfIinsureds.FirstOrDefaultAsync(s => s.Id == id);
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    db.SurveyOfIinsureds.Update(model);
                    await db.SaveChangesAsync();
                }

                TempData["Notif"] = Notification.ShowNotif(MessageType.Delete, type: ToastType.red);

                return PartialView("_Succefullyresponse", redirecturl);

            }

            TempData["Notif"] = Notification.ShowNotif(MessageType.deleteError, type: ToastType.yellow);

            return RedirectToAction("Index");

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

                worksheet.Cells[1, 2].Value = "شهر";
                worksheet.Cells[1, 2].Style.Font.Size = 12;
                worksheet.Cells[1, 2].Style.Font.Bold = true;
                worksheet.Cells[1, 2].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 3].Value = "نام بیمارستان";
                worksheet.Cells[1, 3].Style.Font.Size = 12;
                worksheet.Cells[1, 3].Style.Font.Bold = true;
                worksheet.Cells[1, 3].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 4].Value = "محل بیمارستان";
                worksheet.Cells[1, 4].Style.Font.Size = 12;
                worksheet.Cells[1, 4].Style.Font.Bold = true;
                worksheet.Cells[1, 4].Style.Border.Top.Style = ExcelBorderStyle.Hair;


                worksheet.Cells[1, 5].Value = "نوع بیمارستان";
                worksheet.Cells[1, 5].Style.Font.Size = 12;
                worksheet.Cells[1, 5].Style.Font.Bold = true;
                worksheet.Cells[1, 5].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 6].Value = "نوع بیمه";
                worksheet.Cells[1, 6].Style.Font.Size = 12;
                worksheet.Cells[1, 6].Style.Font.Bold = true;
                worksheet.Cells[1, 6].Style.Border.Top.Style = ExcelBorderStyle.Hair;


                worksheet.Cells[1, 7].Value = "توضیحات";
                worksheet.Cells[1, 7].Style.Font.Size = 12;
                worksheet.Cells[1, 7].Style.Font.Bold = true;
                worksheet.Cells[1, 7].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 8].Value = "سوال اول";
                worksheet.Cells[1, 8].Style.Font.Size = 12;
                worksheet.Cells[1, 8].Style.Font.Bold = true;
                worksheet.Cells[1, 8].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 9].Value = "سوال دوم";
                worksheet.Cells[1, 9].Style.Font.Size = 12;
                worksheet.Cells[1, 9].Style.Font.Bold = true;
                worksheet.Cells[1, 9].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 10].Value = "سوال سوم";
                worksheet.Cells[1, 10].Style.Font.Size = 12;
                worksheet.Cells[1, 10].Style.Font.Bold = true;
                worksheet.Cells[1, 10].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 11].Value = "سوال چهارم";
                worksheet.Cells[1, 11].Style.Font.Size = 12;
                worksheet.Cells[1, 11].Style.Font.Bold = true;
                worksheet.Cells[1, 11].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 12].Value = "سوال پنجم";
                worksheet.Cells[1, 12].Style.Font.Size = 12;
                worksheet.Cells[1, 12].Style.Font.Bold = true;
                worksheet.Cells[1, 12].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 13].Value = "سوال ششم";
                worksheet.Cells[1, 13].Style.Font.Size = 12;
                worksheet.Cells[1, 13].Style.Font.Bold = true;
                worksheet.Cells[1, 13].Style.Border.Top.Style = ExcelBorderStyle.Hair;




                //var select = _context.View_Comment.OrderByDescending(c => c.idComment).ToList();
                var select = _context.SurveyOfIinsureds.Include(c => c.TblCity).Include(c => c.TblBime).ToList();

                //string fromdate1 = HttpContext.Session.GetString("cFromdate1");
                //string todate1 = HttpContext.Session.GetString("cTodate1");

                //if (fromdate1 != "null" && todate1 == "null")
                //{
                //    select = select.Where(m => m.ComDate.CompareTo(fromdate1) >= 0).ToList();

                //}
                //else if (todate1 != "null" && fromdate1 == "null")
                //{
                //    select = select.Where(m => m.ComDate.CompareTo(todate1) <= 0).ToList();
                //}
                //else if (fromdate1 != "null" && todate1 != "null")
                //{

                //    select = select.Where(m => m.ComDate.CompareTo(fromdate1) >= 0 && m.ComDate.CompareTo(todate1) <= 0)
                //        .ToList();
                //}


                int i = 2;
                foreach (var item in select)
                {
                    worksheet.Cells[i, 1].Value = item.Id;
                    worksheet.Cells[i, 1].Style.Font.Size = 12;
                    worksheet.Cells[i, 1].Style.Border.Top.Style = ExcelBorderStyle.Hair;


                    worksheet.Cells[i, 2].Value = item?.TblCity?.CityName;
                    worksheet.Cells[i, 2].Style.Font.Size = 12;
                    worksheet.Cells[i, 2].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 3].Value = item.hospitalName;
                    worksheet.Cells[i, 3].Style.Font.Size = 12;
                    worksheet.Cells[i, 3].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 4].Value = item.hospitalStay;
                    worksheet.Cells[i, 4].Style.Font.Size = 12;
                    worksheet.Cells[i, 4].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    if (item.hospitalOwnership)
                    {
                        worksheet.Cells[i, 5].Value = "خصوصی";
                        worksheet.Cells[i, 5].Style.Font.Size = 12;
                        worksheet.Cells[i, 5].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                    }
                    else
                    {
                        worksheet.Cells[i, 5].Value = "دولتی";
                        worksheet.Cells[i, 5].Style.Font.Size = 12;
                        worksheet.Cells[i, 5].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                    }

                   

                    worksheet.Cells[i, 6].Value = item?.TblBime.BimeType;
                    worksheet.Cells[i, 6].Style.Font.Size = 12;
                    worksheet.Cells[i, 6].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 7].Value = item.Des;
                    worksheet.Cells[i, 7].Style.Font.Size = 12;
                    worksheet.Cells[i, 7].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 8].Value = item.IdQ1;
                    worksheet.Cells[i, 8].Style.Font.Size = 12;
                    worksheet.Cells[i, 8].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 9].Value = item.IdQ2;
                    worksheet.Cells[i, 9].Style.Font.Size = 12;
                    worksheet.Cells[i, 9].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 10].Value = item.IdQ3;
                    worksheet.Cells[i, 10].Style.Font.Size = 12;
                    worksheet.Cells[i, 10].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 11].Value = item.IdQ4;
                    worksheet.Cells[i, 11].Style.Font.Size = 12;
                    worksheet.Cells[i, 11].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 12].Value = item.IdQ5;
                    worksheet.Cells[i, 12].Style.Font.Size = 12;
                    worksheet.Cells[i, 12].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 13].Value = item.IdQ6;
                    worksheet.Cells[i, 13].Style.Font.Size = 12;
                    worksheet.Cells[i, 13].Style.Border.Top.Style = ExcelBorderStyle.Hair;

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
    }
}