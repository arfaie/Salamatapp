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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.OData.Query.SemanticAst;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace Application.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceTableController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public ServiceTableController(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public async Task<IActionResult> Index()
        {
            ClsNavbar clsNavbar = new ClsNavbar(_context);
            ServiceTableNavbar servicetablenavbar = new ServiceTableNavbar();

            var select = await _context.ServiceTables.Include(s => s.TblCity).Include(s => s.TblEducation)
                .ToListAsync();

            servicetablenavbar.ServiceTables = select;
            servicetablenavbar.CommentListNavbar = await clsNavbar.Comment();
            servicetablenavbar.ComplaintsListNavbar = await clsNavbar.Complaint();
            servicetablenavbar.commentcount = servicetablenavbar.CommentListNavbar.Count;
            servicetablenavbar.complaintcount = servicetablenavbar.ComplaintsListNavbar.Count;

            return View(servicetablenavbar);
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddEdit(int id)
        {
            var model = await _context.ServiceTables.FirstOrDefaultAsync(c => c.Id == id);

            ViewBag.City = new SelectList(await _context.TblCity_.ToListAsync(), "idCity", "CityName");

            ViewBag.Edu = new SelectList(await _context.tbl_Education.ToListAsync(), "idEdu", "EduName");

            if (model != null)
            {
                return PartialView("AddEdit", model);
            }

            return PartialView("AddEdit", new ServiceTable());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEdit(string id, ServiceTable model, string redirectUrl)
        {
            if (ModelState.IsValid)
            {
                if (String.IsNullOrWhiteSpace(id))
                {
                    await _context.ServiceTables.AddAsync(model);
                    await _context.SaveChangesAsync();

                    TempData["Notification"] = Notification.ShowNotif(MessageType.Add, ToastType.green);
                    return PartialView("_Succefullyresponse", redirectUrl);
                }

                _context.ServiceTables.Update(model);
                await _context.SaveChangesAsync();

                TempData["Notification"] = Notification.ShowNotif(MessageType.Edit, ToastType.blue);
                return PartialView("_Succefullyresponse", redirectUrl);
            }

            return PartialView("AddEdit", model);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var servicetable = new ServiceTable();
            if (Id != 0)
            {
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    servicetable = await _context.ServiceTables.FirstOrDefaultAsync(s => s.Id == Id);
                    if (servicetable == null)
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

                var model = await _context.ServiceTables.FirstOrDefaultAsync(s => s.Id == id);
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    db.ServiceTables.Update(model);
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

                worksheet.Cells[1, 2].Value = "جنسیت";
                worksheet.Cells[1, 2].Style.Font.Size = 12;
                worksheet.Cells[1, 2].Style.Font.Bold = true;
                worksheet.Cells[1, 2].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 3].Value = "شهرستان";
                worksheet.Cells[1, 3].Style.Font.Size = 12;
                worksheet.Cells[1, 3].Style.Font.Bold = true;
                worksheet.Cells[1, 3].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 4].Value = "سن";
                worksheet.Cells[1, 4].Style.Font.Size = 12;
                worksheet.Cells[1, 4].Style.Font.Bold = true;
                worksheet.Cells[1, 4].Style.Border.Top.Style = ExcelBorderStyle.Hair;


                worksheet.Cells[1, 5].Value = "تحصیلات";
                worksheet.Cells[1, 5].Style.Font.Size = 12;
                worksheet.Cells[1, 5].Style.Font.Bold = true;
                worksheet.Cells[1, 5].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 6].Value = "شغل";
                worksheet.Cells[1, 6].Style.Font.Size = 12;
                worksheet.Cells[1, 6].Style.Font.Bold = true;
                worksheet.Cells[1, 6].Style.Border.Top.Style = ExcelBorderStyle.Hair;


                worksheet.Cells[1, 7].Value = "برای دریافت چه خدمتی مراجعه نموده اید؟";
                worksheet.Cells[1, 7].Style.Font.Size = 12;
                worksheet.Cells[1, 7].Style.Font.Bold = true;
                worksheet.Cells[1, 7].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 8].Value = "دفعات مراجعه برای دریافت خدمت در سال اخیر:";
                worksheet.Cells[1, 8].Style.Font.Size = 12;
                worksheet.Cells[1, 8].Style.Font.Bold = true;
                worksheet.Cells[1, 8].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 9].Value = "سوال اول";
                worksheet.Cells[1, 9].Style.Font.Size = 12;
                worksheet.Cells[1, 9].Style.Font.Bold = true;
                worksheet.Cells[1, 9].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 10].Value = "سوال دوم";
                worksheet.Cells[1, 10].Style.Font.Size = 12;
                worksheet.Cells[1, 10].Style.Font.Bold = true;
                worksheet.Cells[1, 10].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 11].Value = "سوال سوم";
                worksheet.Cells[1, 11].Style.Font.Size = 12;
                worksheet.Cells[1, 11].Style.Font.Bold = true;
                worksheet.Cells[1, 11].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 12].Value = "سوال چهارم";
                worksheet.Cells[1, 12].Style.Font.Size = 12;
                worksheet.Cells[1, 12].Style.Font.Bold = true;
                worksheet.Cells[1, 12].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 13].Value = "سوال پنجم";
                worksheet.Cells[1, 13].Style.Font.Size = 12;
                worksheet.Cells[1, 13].Style.Font.Bold = true;
                worksheet.Cells[1, 13].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 14].Value = "سوال ششم";
                worksheet.Cells[1, 14].Style.Font.Size = 12;
                worksheet.Cells[1, 14].Style.Font.Bold = true;
                worksheet.Cells[1, 14].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 15].Value = "سوال هفتم";
                worksheet.Cells[1, 15].Style.Font.Size = 12;
                worksheet.Cells[1, 15].Style.Font.Bold = true;
                worksheet.Cells[1, 15].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 16].Value = "سوال هشتم";
                worksheet.Cells[1, 16].Style.Font.Size = 12;
                worksheet.Cells[1, 16].Style.Font.Bold = true;
                worksheet.Cells[1, 16].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 17].Value = "سوال نهم";
                worksheet.Cells[1, 17].Style.Font.Size = 12;
                worksheet.Cells[1, 17].Style.Font.Bold = true;
                worksheet.Cells[1, 17].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 18].Value = "سوال دهم";
                worksheet.Cells[1, 18].Style.Font.Size = 12;
                worksheet.Cells[1, 18].Style.Font.Bold = true;
                worksheet.Cells[1, 18].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 19].Value = "سوال یازدهم";
                worksheet.Cells[1, 19].Style.Font.Size = 12;
                worksheet.Cells[1, 19].Style.Font.Bold = true;
                worksheet.Cells[1, 19].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 20].Value = "سوال دوازدهم";
                worksheet.Cells[1, 20].Style.Font.Size = 12;
                worksheet.Cells[1, 20].Style.Font.Bold = true;
                worksheet.Cells[1, 20].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 21].Value = "سوال سیزدهم";
                worksheet.Cells[1, 21].Style.Font.Size = 12;
                worksheet.Cells[1, 21].Style.Font.Bold = true;
                worksheet.Cells[1, 21].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 22].Value = "سوال چهاردم";
                worksheet.Cells[1, 22].Style.Font.Size = 12;
                worksheet.Cells[1, 22].Style.Font.Bold = true;
                worksheet.Cells[1, 22].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 23].Value = "سوال پانزدهم";
                worksheet.Cells[1, 23].Style.Font.Size = 12;
                worksheet.Cells[1, 23].Style.Font.Bold = true;
                worksheet.Cells[1, 23].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 24].Value = "سوال شانزدهم";
                worksheet.Cells[1, 24].Style.Font.Size = 12;
                worksheet.Cells[1, 24].Style.Font.Bold = true;
                worksheet.Cells[1, 24].Style.Border.Top.Style = ExcelBorderStyle.Hair;


                //var select = _context.View_Comment.OrderByDescending(c => c.idComment).ToList();
                var select = _context.ServiceTables.Include(c => c.TblCity).Include(c => c.TblEducation).ToList();

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


                    worksheet.Cells[i, 2].Value = item.Gender;
                    worksheet.Cells[i, 2].Style.Font.Size = 12;
                    worksheet.Cells[i, 2].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 3].Value = item?.TblCity?.CityName;
                    worksheet.Cells[i, 3].Style.Font.Size = 12;
                    worksheet.Cells[i, 3].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 4].Value = item.Age;
                    worksheet.Cells[i, 4].Style.Font.Size = 12;
                    worksheet.Cells[i, 4].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 5].Value = item?.TblEducation?.EduName;
                    worksheet.Cells[i, 5].Style.Font.Size = 12;
                    worksheet.Cells[i, 5].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 6].Value = item.Job;
                    worksheet.Cells[i, 6].Style.Font.Size = 12;
                    worksheet.Cells[i, 6].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 7].Value = item.WicheService;
                    worksheet.Cells[i, 7].Style.Font.Size = 12;
                    worksheet.Cells[i, 7].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 8].Value = item.FlagMoraje;
                    worksheet.Cells[i, 8].Style.Font.Size = 12;
                    worksheet.Cells[i, 8].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 9].Value = item.IdQ1;
                    worksheet.Cells[i, 9].Style.Font.Size = 12;
                    worksheet.Cells[i, 9].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 10].Value = item.IdQ2;
                    worksheet.Cells[i, 10].Style.Font.Size = 12;
                    worksheet.Cells[i, 10].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 11].Value = item.IdQ3;
                    worksheet.Cells[i, 11].Style.Font.Size = 12;
                    worksheet.Cells[i, 11].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 12].Value = item.IdQ4;
                    worksheet.Cells[i, 12].Style.Font.Size = 12;
                    worksheet.Cells[i, 12].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 13].Value = item.IdQ5;
                    worksheet.Cells[i, 13].Style.Font.Size = 12;
                    worksheet.Cells[i, 13].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 14].Value = item.IdQ6;
                    worksheet.Cells[i, 14].Style.Font.Size = 12;
                    worksheet.Cells[i, 14].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 15].Value = item.IdQ7;
                    worksheet.Cells[i, 15].Style.Font.Size = 12;
                    worksheet.Cells[i, 15].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 16].Value = item.IdQ8;
                    worksheet.Cells[i, 16].Style.Font.Size = 12;
                    worksheet.Cells[i, 16].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 17].Value = item.IdQ9;
                    worksheet.Cells[i, 17].Style.Font.Size = 12;
                    worksheet.Cells[i, 17].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 18].Value = item.IdQ10;
                    worksheet.Cells[i, 18].Style.Font.Size = 12;
                    worksheet.Cells[i, 18].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 19].Value = item.IdQ11;
                    worksheet.Cells[i, 19].Style.Font.Size = 12;
                    worksheet.Cells[i, 19].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 20].Value = item.IdQ12;
                    worksheet.Cells[i, 20].Style.Font.Size = 12;
                    worksheet.Cells[i, 20].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 21].Value = item.IdQ13;
                    worksheet.Cells[i, 21].Style.Font.Size = 12;
                    worksheet.Cells[i, 21].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 22].Value = item.IdQ14;
                    worksheet.Cells[i, 22].Style.Font.Size = 12;
                    worksheet.Cells[i, 22].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 23].Value = item.IdQ15;
                    worksheet.Cells[i, 23].Style.Font.Size = 12;
                    worksheet.Cells[i, 23].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 24].Value = item.IdQ16;
                    worksheet.Cells[i, 24].Style.Font.Size = 12;
                    worksheet.Cells[i, 24].Style.Border.Top.Style = ExcelBorderStyle.Hair;

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