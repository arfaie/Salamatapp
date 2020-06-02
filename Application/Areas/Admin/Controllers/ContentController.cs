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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public ContentController(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public async Task<IActionResult> Index()
        {
            ClsNavbar clsNavbar = new ClsNavbar(_context);
            ContentNavbar contentNavbar = new ContentNavbar();

            var select = await _context.TblContent.Where(x => x.flag == true).ToListAsync();

            contentNavbar.tblContents = select;
            contentNavbar.CommentListNavbar = await clsNavbar.Comment();
            contentNavbar.ComplaintsListNavbar = await clsNavbar.Complaint();
            contentNavbar.commentcount = contentNavbar.CommentListNavbar.Count;
            contentNavbar.complaintcount = contentNavbar.ComplaintsListNavbar.Count;

            return View(contentNavbar);
        }

        [HttpGet]
        public async Task<IActionResult> AddEditContent(int Id)
        {
            var Content = new TblContent();
            if (Id != 0)
            {
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    Content = await _context.TblContent.Where(c => c.ContentId == Id).SingleOrDefaultAsync();
                    if (Content == null)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return PartialView("AddEditContent", Content);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditContent(TblContent model, int id, string redirecturl)
        {
            if (ModelState.IsValid)
            {
                string ContenteDate = "";
                if (id == 0)
                {
                    using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                    {
                        model.flag = true;
                        model.ContenteDate = ContenteDate.GetLastUpdate();
                        db.TblContent.Add(model);
                        await db.SaveChangesAsync();
                    }
                    TempData["Notif"] = Notification.ShowNotif(MessageType.Add, type: ToastType.green);
                    return PartialView("_Succefullyresponse", redirecturl);
                }
                else
                {
                    using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                    {
                        model.flag = true;
                        model.ContenteDate = ContenteDate.GetLastUpdate();
                        db.TblContent.Update(model);
                        await db.SaveChangesAsync();
                    }
                    TempData["Notif"] = Notification.ShowNotif(MessageType.Edit, type: ToastType.blue);
                    return PartialView("_Succefullyresponse", redirecturl);
                }
            }
            else
            {
                if (id == 0)
                {
                    TempData["Notif"] = Notification.ShowNotif(MessageType.addError, type: ToastType.yellow);
                }
                else
                {
                    TempData["Notif"] = Notification.ShowNotif(MessageType.editError, type: ToastType.yellow);
                }
                return PartialView("AddEditContent", model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteContent(int Id)
        {
            var Content = new TblContent();
            if (Id != 0)
            {
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    Content = await _context.TblContent.Where(i => i.ContentId == Id).SingleOrDefaultAsync();
                    if (Content == null)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return PartialView("DeleteContent", Content.contentTitel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteContent(int id, string redirecturl)
        {
            if (ModelState.IsValid)
            {
                string ContenteDate = "";
                TblContent model = await _context.TblContent.Where(i => i.ContentId == id).SingleOrDefaultAsync();
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    model.flag = false;
                    model.ContenteDate = ContenteDate.GetLastUpdate();
                    db.TblContent.Update(model);
                    await db.SaveChangesAsync();
                }
                TempData["Notif"] = Notification.ShowNotif(MessageType.Delete, type: ToastType.red);
               
                return PartialView("_Succefullyresponse", redirecturl);
            }
            else
            {
                TempData["Notif"] = Notification.ShowNotif(MessageType.deleteError, type: ToastType.yellow);
                
                return RedirectToAction("Index");
            }
        }
    }
}