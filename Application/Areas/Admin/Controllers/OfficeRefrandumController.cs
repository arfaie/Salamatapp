using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Helpers.OptionEnums;
using Application.Models;
using Application.Models.Helpers;
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
    public class OfficeRefrandumController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public OfficeRefrandumController(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public async Task<IActionResult> Index()
        {
            ClsNavbar clsNavbar = new ClsNavbar(_context);
            OfficeRefruadumNavbar surveyOfIinsuredNavbar = new OfficeRefruadumNavbar();

            var select = await _context.OfficeRefrandums.Include(s => s.TblLongOfService).Include(s => s.TblEducation2)
                .Include(s => s.EmployeeType).Include(s => s.TblPersonal)
                .ToListAsync();

            surveyOfIinsuredNavbar.OfficeRefrandum = select;
            surveyOfIinsuredNavbar.CommentListNavbar = await clsNavbar.Comment();
            surveyOfIinsuredNavbar.ComplaintsListNavbar = await clsNavbar.Complaint();
            surveyOfIinsuredNavbar.commentcount = surveyOfIinsuredNavbar.CommentListNavbar.Count;
            surveyOfIinsuredNavbar.complaintcount = surveyOfIinsuredNavbar.ComplaintsListNavbar.Count;
            ViewBag.Persons = _context.TblPersonal.ToList();
            return View(surveyOfIinsuredNavbar);
        }

       
       
        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var OfficeRefrandum = new OfficeRefrandum();
            if (Id != 0)
            {
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    OfficeRefrandum = await _context.OfficeRefrandums.FirstOrDefaultAsync(s => s.Id == Id);
                    if (OfficeRefrandum == null)
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

                var model = await _context.OfficeRefrandums.FirstOrDefaultAsync(s => s.Id == id);
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    db.OfficeRefrandums.Update(model);
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

                worksheet.Cells[1, 2].Value = "کامند مربوطه";
                worksheet.Cells[1, 2].Style.Font.Size = 12;
                worksheet.Cells[1, 2].Style.Font.Bold = true;
                worksheet.Cells[1, 2].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 3].Value = "جنسیت";
                worksheet.Cells[1, 3].Style.Font.Size = 12;
                worksheet.Cells[1, 3].Style.Font.Bold = true;
                worksheet.Cells[1, 3].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 4].Value = "وضعیت تاهل";
                worksheet.Cells[1, 4].Style.Font.Size = 12;
                worksheet.Cells[1, 4].Style.Font.Bold = true;
                worksheet.Cells[1, 4].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 5].Value = "سابقه خدمت";
                worksheet.Cells[1, 5].Style.Font.Size = 12;
                worksheet.Cells[1, 5].Style.Font.Bold = true;
                worksheet.Cells[1, 5].Style.Border.Top.Style = ExcelBorderStyle.Hair;


                worksheet.Cells[1, 6].Value = "میزان تحصیلات";
                worksheet.Cells[1, 6].Style.Font.Size = 12;
                worksheet.Cells[1, 6].Style.Font.Bold = true;
                worksheet.Cells[1, 6].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 7].Value = "نوع استخدام";
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

                worksheet.Cells[1, 14].Value = "سوال هفتم";
                worksheet.Cells[1, 14].Style.Font.Size = 12;
                worksheet.Cells[1, 14].Style.Font.Bold = true;
                worksheet.Cells[1, 14].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 15].Value = "سوال هشتم";
                worksheet.Cells[1, 15].Style.Font.Size = 12;
                worksheet.Cells[1, 15].Style.Font.Bold = true;
                worksheet.Cells[1, 15].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 16].Value = "سوال نهم";
                worksheet.Cells[1, 16].Style.Font.Size = 12;
                worksheet.Cells[1, 16].Style.Font.Bold = true;
                worksheet.Cells[1, 16].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 13].Value = "سوال دهم";
                worksheet.Cells[1, 13].Style.Font.Size = 12;
                worksheet.Cells[1, 13].Style.Font.Bold = true;
                worksheet.Cells[1, 13].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 17].Value = "سوال یازدهم";
                worksheet.Cells[1, 17].Style.Font.Size = 12;
                worksheet.Cells[1, 17].Style.Font.Bold = true;
                worksheet.Cells[1, 17].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                

                worksheet.Cells[1, 18].Value = "نظر یا پیشنهاد";
                worksheet.Cells[1, 18].Style.Font.Size = 12;
                worksheet.Cells[1, 18].Style.Font.Bold = true;
                worksheet.Cells[1, 18].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 19].Value = "تاریخ ثبت";
                worksheet.Cells[1, 19].Style.Font.Size = 12;
                worksheet.Cells[1, 19].Style.Font.Bold = true;
                worksheet.Cells[1, 19].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                var select = _context.OfficeRefrandums.Include(s => s.TblLongOfService).Include(s => s.TblEducation2)
                .Include(s => s.EmployeeType).Include(s => s.TblPersonal).ToList();



                int i = 2;
                foreach (var item in select)
                {
                    worksheet.Cells[i, 1].Value = item.Id;
                    worksheet.Cells[i, 1].Style.Font.Size = 12;
                    worksheet.Cells[i, 1].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 2].Value = PersonName(item.idPerson);
                    worksheet.Cells[i, 2].Style.Font.Size = 12;
                    worksheet.Cells[i, 2].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    string gender = "";
                    if (item.Gender)
                    {
                        gender = "مرد";
                    }
                    else
                    {
                        gender = "زن";
                    }
                    worksheet.Cells[i, 3].Value = gender;
                    worksheet.Cells[i, 3].Style.Font.Size = 12;
                    worksheet.Cells[i, 3].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    string married = "";
                    if (item.isMarried)
                    {
                        married = "متاهل";
                    }
                    else
                    {
                        married = "مجرد";
                    }
                    worksheet.Cells[i, 4].Value = married;
                    worksheet.Cells[i, 4].Style.Font.Size = 12;
                    worksheet.Cells[i, 4].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 5].Value = item?.TblLongOfService?.Title;
                    worksheet.Cells[i, 5].Style.Font.Size = 12;
                    worksheet.Cells[i, 5].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 6].Value = item?.TblEducation2?.Title;
                    worksheet.Cells[i, 6].Style.Font.Size = 12;
                    worksheet.Cells[i, 6].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 7].Value = item?.EmployeeType?.Title;
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

                    worksheet.Cells[i, 14].Value = item.IdQ7;
                    worksheet.Cells[i, 14].Style.Font.Size = 12;
                    worksheet.Cells[i, 14].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 13].Value = item.IdQ8;
                    worksheet.Cells[i, 13].Style.Font.Size = 12;
                    worksheet.Cells[i, 13].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 15].Value = item.IdQ9;
                    worksheet.Cells[i, 15].Style.Font.Size = 12;
                    worksheet.Cells[i, 15].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 16].Value = item.IdQ10;
                    worksheet.Cells[i, 16].Style.Font.Size = 12;
                    worksheet.Cells[i, 16].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 17].Value = item.IdQ11;
                    worksheet.Cells[i, 17].Style.Font.Size = 12;
                    worksheet.Cells[i, 17].Style.Border.Top.Style = ExcelBorderStyle.Hair;


                    worksheet.Cells[i, 18].Value = item.Des;
                    worksheet.Cells[i, 18].Style.Font.Size = 12;
                    worksheet.Cells[i, 18].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 19].Value = item.SubmitDateTime.toShamsi();
                    worksheet.Cells[i, 19].Style.Font.Size = 12;
                    worksheet.Cells[i, 19].Style.Border.Top.Style = ExcelBorderStyle.Hair;

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
                fileDownloadName: DateTime.Now.Date.ToShortDateString() + "_نظرسنجی_کاکنان.xlsx"
            );


        }

        public string PersonName(int id)
        {
            var person=_context.TblPersonal.Where(x => x.idPerson == id).FirstOrDefault();
            if (person != null)
            {
                string name = person.fname + " " + person.family;
                return name;
            }
            else
                return null;
        }
    }
}