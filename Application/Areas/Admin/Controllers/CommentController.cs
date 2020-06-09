using Application.Models;
using Application.Models.NavbarModels;
using Application.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Application.Net;
using Application.Helpers.OptionEnums;
using Application.Net.OptionEnums;

namespace Application.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CommentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public CommentController(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public async Task<IActionResult> Index()
        {
            HttpContext.Session.SetString("cFromdate1", "null");
            HttpContext.Session.SetString("cTodate1", "null");

            ClsNavbar clsNavbar = new ClsNavbar(_context);
            CommentNavbar commentNavbar = new CommentNavbar();

            var select = await _context.View_Comment.OrderByDescending(c => c.idComment).ToListAsync();

            List<CommentListViewModel> models = new List<CommentListViewModel>();

            foreach (var item in select)
            {
                CommentListViewModel model = new CommentListViewModel
                {
                    idComment = item.idComment,
                    age = item.age,
                    CommentText = item.CommentText,
                    ComTime = item.ComTime,
                    ComDate = item.ComDate,
                    FirstPerson = item.FirstPerson,
                    SecondPeson = item.SecondPeson,
                    idState = item.idState,
                    idSex = item.idSex,
                    idEducation = item.idEdu,
                    idBime = item.idBime,
                    idMoraje = item.idMoraje,
                    idReason = item.idReason,
                    StateName = item.StateName,
                    sexName = item.sexName,
                    EduName = item.EduName,
                    BimeType = item.BimeType,
                    Moraje = item.Moraje,
                    ReasonText = item.ReasonText,
                    flag=item.flag,
                    IdQ1 = getArzyabi(item.IdQ1),
                    IdQ2 = getArzyabi(item.IdQ2),
                    IdQ3 = getArzyabi(item.IdQ3),
                    IdQ4 = getArzyabi(item.IdQ4),
                    IdQ5 = getArzyabi(item.IdQ5),
                    IdQ6 = getArzyabi(item.IdQ6)
                };

                models.Add(model);

            }

            commentNavbar.commentListViewModels = models;

            commentNavbar.CommentListNavbar = await clsNavbar.Comment();
            commentNavbar.ComplaintsListNavbar = await clsNavbar.Complaint();

            commentNavbar.commentcount = commentNavbar.CommentListNavbar.Count;
            commentNavbar.complaintcount = commentNavbar.ComplaintsListNavbar.Count;

            return View(commentNavbar);
        }

        public string getArzyabi(int id)
        {
            var SelectArzyabi = _context.tbl_Arzyabi.ToList();
            string q = SelectArzyabi.Where(x => x.idArzyabi == id).SingleOrDefault().Arzyabi;
            return q;
        }



        public async Task<IActionResult> commentSearch(string fromdate1, string todate1)
        {
            ClsNavbar clsNavbar = new ClsNavbar(_context);
            CommentNavbar commentNavbar = new CommentNavbar();

            HttpContext.Session.SetString("cFromdate1", "null");
            HttpContext.Session.SetString("cTodate1", "null");

            var select = await _context.View_Comment.OrderByDescending(c => c.idComment)
                .ToListAsync();


            if (fromdate1 != null && todate1 == null)
            {
                select = select.Where(m => m.ComDate.CompareTo(fromdate1) >= 0).ToList();
                HttpContext.Session.SetString("cFromdate1", fromdate1);
            }

            if (todate1 != null && fromdate1 == null)
            {
                select = select.Where(m => m.ComDate.CompareTo(todate1) <= 0).ToList();
                HttpContext.Session.SetString("cTodate1", todate1);
            }

            if (fromdate1 != null && todate1 != null)
            {
                HttpContext.Session.SetString("cFromdate1", fromdate1);
                HttpContext.Session.SetString("cTodate1", todate1);
                select = select.Where(m => m.ComDate.CompareTo(fromdate1) >= 0 && m.ComDate.CompareTo(todate1) <= 0)
                    .ToList();

            }


            List<CommentListViewModel> models = new List<CommentListViewModel>();

            foreach (var item in select)
            {
                CommentListViewModel model = new CommentListViewModel
                {
                    idComment = item.idComment,
                    age = item.age,
                    CommentText = item.CommentText,
                    ComTime = item.ComTime,
                    ComDate = item.ComDate,
                    FirstPerson = item.FirstPerson,
                    SecondPeson = item.SecondPeson,
                    idState = item.idState,
                    idSex = item.idSex,
                    idEducation = item.idEdu,
                    idBime = item.idBime,
                    idMoraje = item.idMoraje,
                    idReason = item.idReason,
                    StateName = item.StateName,
                    sexName = item.sexName,
                    EduName = item.EduName,
                    BimeType = item.BimeType,
                    Moraje = item.Moraje,
                    ReasonText = item.ReasonText,

                    IdQ1 = getArzyabi(item.IdQ1),
                    IdQ2 = getArzyabi(item.IdQ2),
                    IdQ3 = getArzyabi(item.IdQ3),
                    IdQ4 = getArzyabi(item.IdQ4),
                    IdQ5 = getArzyabi(item.IdQ5),
                    IdQ6 = getArzyabi(item.IdQ6)
                };

                models.Add(model);

            }

            commentNavbar.commentListViewModels = models;
            commentNavbar.CommentListNavbar = await clsNavbar.Comment();
            commentNavbar.ComplaintsListNavbar = await clsNavbar.Complaint();

            commentNavbar.commentcount = commentNavbar.CommentListNavbar.Count;
            commentNavbar.complaintcount = commentNavbar.ComplaintsListNavbar.Count;

            return View("Index", commentNavbar);
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


                worksheet.Cells[1, 2].Value = "شهرستان";
                worksheet.Cells[1, 2].Style.Font.Size = 12;
                worksheet.Cells[1, 2].Style.Font.Bold = true;
                worksheet.Cells[1, 2].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 3].Value = "جنسیت";
                worksheet.Cells[1, 3].Style.Font.Size = 12;
                worksheet.Cells[1, 3].Style.Font.Bold = true;
                worksheet.Cells[1, 3].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 4].Value = "سن";
                worksheet.Cells[1, 4].Style.Font.Size = 12;
                worksheet.Cells[1, 4].Style.Font.Bold = true;
                worksheet.Cells[1, 4].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 5].Value = "تاریخ و زمان";
                worksheet.Cells[1, 5].Style.Font.Size = 12;
                worksheet.Cells[1, 5].Style.Font.Bold = true;
                worksheet.Cells[1, 5].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 6].Value = "تحصیلات";
                worksheet.Cells[1, 6].Style.Font.Size = 12;
                worksheet.Cells[1, 6].Style.Font.Bold = true;
                worksheet.Cells[1, 6].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 7].Value = "نوع بیمه";
                worksheet.Cells[1, 7].Style.Font.Size = 12;
                worksheet.Cells[1, 7].Style.Font.Bold = true;
                worksheet.Cells[1, 7].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 8].Value = "تعداد مراجعه";
                worksheet.Cells[1, 8].Style.Font.Size = 12;
                worksheet.Cells[1, 8].Style.Font.Bold = true;
                worksheet.Cells[1, 8].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 9].Value = "علت مراجعه";
                worksheet.Cells[1, 9].Style.Font.Size = 12;
                worksheet.Cells[1, 9].Style.Font.Bold = true;
                worksheet.Cells[1, 9].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 10].Value = "مناسب ترین برخورد";
                worksheet.Cells[1, 10].Style.Font.Size = 12;
                worksheet.Cells[1, 10].Style.Font.Bold = true;
                worksheet.Cells[1, 10].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 11].Value = "برخورد نامناسب";
                worksheet.Cells[1, 11].Style.Font.Size = 12;
                worksheet.Cells[1, 11].Style.Font.Bold = true;
                worksheet.Cells[1, 11].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 12].Value = "سوال اول";
                worksheet.Cells[1, 12].Style.Font.Size = 12;
                worksheet.Cells[1, 12].Style.Font.Bold = true;
                worksheet.Cells[1, 12].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 13].Value = "سوال دوم";
                worksheet.Cells[1, 13].Style.Font.Size = 12;
                worksheet.Cells[1, 13].Style.Font.Bold = true;
                worksheet.Cells[1, 13].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 14].Value = "سوال سوم";
                worksheet.Cells[1, 14].Style.Font.Size = 12;
                worksheet.Cells[1, 14].Style.Font.Bold = true;
                worksheet.Cells[1, 14].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 15].Value = "سوال چهارم";
                worksheet.Cells[1, 15].Style.Font.Size = 12;
                worksheet.Cells[1, 15].Style.Font.Bold = true;
                worksheet.Cells[1, 15].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 16].Value = "سوال پنجم";
                worksheet.Cells[1, 16].Style.Font.Size = 12;
                worksheet.Cells[1, 16].Style.Font.Bold = true;
                worksheet.Cells[1, 16].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                worksheet.Cells[1, 17].Value = "سوال ششم";
                worksheet.Cells[1, 17].Style.Font.Size = 12;
                worksheet.Cells[1, 17].Style.Font.Bold = true;
                worksheet.Cells[1, 17].Style.Border.Top.Style = ExcelBorderStyle.Hair;


                var select = _context.View_Comment.OrderByDescending(c => c.idComment).ToList();

                string fromdate1 = HttpContext.Session.GetString("cFromdate1");
                string todate1 = HttpContext.Session.GetString("cTodate1");

                if (fromdate1 != "null" && todate1 == "null")
                {
                    select = select.Where(m => m.ComDate.CompareTo(fromdate1) >= 0).ToList();

                }
                else if (todate1 != "null" && fromdate1 == "null")
                {
                    select = select.Where(m => m.ComDate.CompareTo(todate1) <= 0).ToList();
                }
                else if (fromdate1 != "null" && todate1 != "null")
                {

                    select = select.Where(m => m.ComDate.CompareTo(fromdate1) >= 0 && m.ComDate.CompareTo(todate1) <= 0)
                        .ToList();
                }


                int i = 2;
                foreach (var item in select)
                {
                    worksheet.Cells[i, 1].Value = item.idComment;
                    worksheet.Cells[i, 1].Style.Font.Size = 12;
                    worksheet.Cells[i, 1].Style.Border.Top.Style = ExcelBorderStyle.Hair;


                    worksheet.Cells[i, 2].Value = item.StateName;
                    worksheet.Cells[i, 2].Style.Font.Size = 12;
                    worksheet.Cells[i, 2].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 3].Value = item.sexName;
                    worksheet.Cells[i, 3].Style.Font.Size = 12;
                    worksheet.Cells[i, 3].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 4].Value = item.age;
                    worksheet.Cells[i, 4].Style.Font.Size = 12;
                    worksheet.Cells[i, 4].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 5].Value = item.ComTime + "-" + item.ComDate;
                    worksheet.Cells[i, 5].Style.Font.Size = 12;
                    worksheet.Cells[i, 5].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 6].Value = item.EduName;
                    worksheet.Cells[i, 6].Style.Font.Size = 12;
                    worksheet.Cells[i, 6].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 7].Value = item.BimeType;
                    worksheet.Cells[i, 7].Style.Font.Size = 12;
                    worksheet.Cells[i, 7].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 8].Value = item.Moraje;
                    worksheet.Cells[i, 8].Style.Font.Size = 12;
                    worksheet.Cells[i, 8].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 9].Value = item.ReasonText;
                    worksheet.Cells[i, 9].Style.Font.Size = 12;
                    worksheet.Cells[i, 9].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 10].Value = item.FirstPerson;
                    worksheet.Cells[i, 10].Style.Font.Size = 12;
                    worksheet.Cells[i, 10].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 11].Value = item.SecondPeson;
                    worksheet.Cells[i, 11].Style.Font.Size = 12;
                    worksheet.Cells[i, 11].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 12].Value = getArzyabi(item.IdQ1);
                    worksheet.Cells[i, 12].Style.Font.Size = 12;
                    worksheet.Cells[i, 12].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 13].Value = getArzyabi(item.IdQ2);
                    worksheet.Cells[i, 13].Style.Font.Size = 12;
                    worksheet.Cells[i, 13].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 14].Value = getArzyabi(item.IdQ3);
                    worksheet.Cells[i, 14].Style.Font.Size = 12;
                    worksheet.Cells[i, 14].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 15].Value = getArzyabi(item.IdQ4);
                    worksheet.Cells[i, 15].Style.Font.Size = 12;
                    worksheet.Cells[i, 15].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 16].Value = getArzyabi(item.IdQ5);
                    worksheet.Cells[i, 16].Style.Font.Size = 12;
                    worksheet.Cells[i, 16].Style.Border.Top.Style = ExcelBorderStyle.Hair;

                    worksheet.Cells[i, 17].Value = getArzyabi(item.IdQ6);
                    worksheet.Cells[i, 17].Style.Font.Size = 12;
                    worksheet.Cells[i, 17].Style.Border.Top.Style = ExcelBorderStyle.Hair;

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
            var select = _context.tbl_Comment.Where(x => x.idComment == id).FirstOrDefault();
            select.flag = true;
            _context.tbl_Comment.Update(select);
            _context.SaveChangesAsync();
            TempData["Notif"] = Notification.ShowNotif(MessageType.Edit, type: ToastType.green);
            return RedirectToAction("index");

        }

        //[HttpGet]
        //public async Task<IActionResult> AddComment()
        //{
        //    AddEditCommentViewModel model = new AddEditCommentViewModel();
        //    model.States = await _context.tbl_State.Select(st => new SelectListItem
        //    {
        //        Text = st.StateName,
        //        Value = st.idState.ToString()

        //    }).ToListAsync();


        //    model.Sexs = await _context.tbl_sex.Select(se => new SelectListItem
        //    {
        //        Text = se.sexName,
        //        Value = se.idSex.ToString()
        //    }).ToListAsync();

        //    model.Educations = await _context.tbl_Education.Select(ed => new SelectListItem
        //    {
        //        Text = ed.EduName,
        //        Value = ed.idEdu.ToString()
        //    }).ToListAsync();

        //    model.Bimes = await _context.tbl_Bime.Select(bi => new SelectListItem
        //    {
        //        Text = bi.BimeType,
        //        Value = bi.idBime.ToString()
        //    }).ToListAsync();

        //    model.Morajes = await _context.tbl_Moraje.Select(mo => new SelectListItem
        //    {
        //        Text = mo.Moraje,
        //        Value = mo.idMoraje.ToString()
        //    }).ToListAsync();

        //    model.Reasons = await _context.tbl_Reason.Select(re => new SelectListItem
        //    {
        //        Text = re.ReasonText,
        //        Value = re.idReason.ToString()
        //    }).ToListAsync();

        //    return PartialView("AddEditComment", model);
        //}

        //[HttpGet]
        //public async Task<IActionResult> EditComment(int id)
        //{
        //    AddEditCommentViewModel model = new AddEditCommentViewModel();
        //    model.States = await _context.tbl_State.Select(st => new SelectListItem
        //    {
        //        Text = st.StateName,
        //        Value = st.idState.ToString()

        //    }).ToListAsync();


        //    model.Sexs = await _context.tbl_sex.Select(se => new SelectListItem
        //    {
        //        Text = se.sexName,
        //        Value = se.idSex.ToString()
        //    }).ToListAsync();

        //    model.Educations = await _context.tbl_Education.Select(ed => new SelectListItem
        //    {
        //        Text = ed.EduName,
        //        Value = ed.idEdu.ToString()
        //    }).ToListAsync();

        //    model.Bimes = await _context.tbl_Bime.Select(bi => new SelectListItem
        //    {
        //        Text = bi.BimeType,
        //        Value = bi.idBime.ToString()
        //    }).ToListAsync();

        //    model.Morajes = await _context.tbl_Moraje.Select(mo => new SelectListItem
        //    {
        //        Text = mo.Moraje,
        //        Value = mo.idMoraje.ToString()
        //    }).ToListAsync();

        //    model.Reasons = await _context.tbl_Reason.Select(re => new SelectListItem
        //    {
        //        Text = re.ReasonText,
        //        Value = re.idReason.ToString()
        //    }).ToListAsync();

        //    if (id != 0)
        //    {
        //        using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
        //        {
        //            tbl_Comment comment = await _context.tbl_Comment.Where(c => c.idComment == id).SingleOrDefaultAsync();
        //            if (comment != null)
        //            {


        //                model.idComment = comment.idComment;
        //                model.age = comment.age;
        //                model.IdQ1 = comment.IdQ1;
        //                model.IdQ2 = comment.IdQ2;
        //                model.IdQ3 = comment.IdQ3;
        //                model.IdQ4 = comment.IdQ4;
        //                model.IdQ5 = comment.IdQ5;
        //                model.IdQ6 = comment.IdQ6;
        //                model.CommentText = comment.CommentText;
        //                model.ComTime = comment.ComTime;
        //                model.flag = comment.flag;
        //                model.ComDate = comment.ComDate;
        //                model.FirstPerson = comment.FirstPerson;
        //                model.SecondPeson = comment.SecondPeson;
        //                model.idState = comment.idState;
        //                model.idSex = comment.idSex;
        //                model.idEducation = comment.idEducation;
        //                model.idBime = comment.idBime;
        //                model.idMoraje = comment.idMoraje;
        //                model.idReason = comment.idReason;

        //            }
        //        }
        //    }

        //    return PartialView("AddEditComment", model);
        //}

        //[HttpPost]
        //public async Task<IActionResult> AddEditComment(int BookId, AddEditCommentViewModel model, string redirecturl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (BookId == 0)
        //        {
        //            //insert
        //            using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
        //            {
        //                tbl_Comment Commentmodel = AutoMapper.Mapper.Map<AddEditCommentViewModel, tbl_Comment>(model);
        //                Commentmodel.flag = true;
        //                db.tbl_Comment.Add(Commentmodel);
        //                await db.SaveChangesAsync();
        //            }

        //            return PartialView("_Succefullyresponse", redirecturl);
        //        }
        //        else
        //        {
        //            //update
        //            using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
        //            {
        //                tbl_Comment Commentmodel = AutoMapper.Mapper.Map<AddEditCommentViewModel, tbl_Comment>(model);
        //                Commentmodel.flag = true;
        //                db.tbl_Comment.Update(Commentmodel);
        //                await db.SaveChangesAsync();
        //            }

        //            return PartialView("_Succefullyresponse", redirecturl);
        //        }
        //    }

        //    model.States = await _context.tbl_State.Select(st => new SelectListItem
        //    {
        //        Text = st.StateName,
        //        Value = st.idState.ToString()

        //    }).ToListAsync();


        //    model.Sexs = await _context.tbl_sex.Select(se => new SelectListItem
        //    {
        //        Text = se.sexName,
        //        Value = se.idSex.ToString()
        //    }).ToListAsync();

        //    model.Educations = await _context.tbl_Education.Select(ed => new SelectListItem
        //    {
        //        Text = ed.EduName,
        //        Value = ed.idEdu.ToString()
        //    }).ToListAsync();

        //    model.Bimes = await _context.tbl_Bime.Select(bi => new SelectListItem
        //    {
        //        Text = bi.BimeType,
        //        Value = bi.idBime.ToString()
        //    }).ToListAsync();

        //    model.Morajes = await _context.tbl_Moraje.Select(mo => new SelectListItem
        //    {
        //        Text = mo.Moraje,
        //        Value = mo.idMoraje.ToString()
        //    }).ToListAsync();

        //    model.Reasons = await _context.tbl_Reason.Select(re => new SelectListItem
        //    {
        //        Text = re.ReasonText,
        //        Value = re.idReason.ToString()
        //    }).ToListAsync();


        //    return PartialView("AddEditComment", model);
        //}
    }
}