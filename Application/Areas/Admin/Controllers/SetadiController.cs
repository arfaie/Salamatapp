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
    public class SetadiController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public SetadiController(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public async Task<IActionResult> Index()
        {
            ClsNavbar clsNavbar = new ClsNavbar(_context);
            SetadiNavbar setadiNavbar = new SetadiNavbar();

            var select = await _context.Tbl_Setadi.Where(x => x.flag == true).ToListAsync();

            setadiNavbar.tblSetadis = select;
            setadiNavbar.CommentListNavbar = await clsNavbar.Comment();
            setadiNavbar.ComplaintsListNavbar = await clsNavbar.Complaint();
            setadiNavbar.commentcount = setadiNavbar.CommentListNavbar.Count;
            setadiNavbar.complaintcount = setadiNavbar.ComplaintsListNavbar.Count;

            return View(setadiNavbar);
        }

        [HttpGet]
        public async Task<IActionResult> AddEditSetadi(int Id)
        {
            var Setadi = new Tbl_Setadi();
            if (Id != 0)
            {
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    Setadi = await _context.Tbl_Setadi.Where(i => i.idSetadi == Id).SingleOrDefaultAsync();
                    if (Setadi == null)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return PartialView("AddEditSetadi", Setadi);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditSetadi(Tbl_Setadi model, int id, string redirecturl)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                    {
                        string lastupdate = "";
                        model.lastUpdate = lastupdate.GetLastUpdate();
                        model.flag = true;
                        db.Tbl_Setadi.Add(model);
                        await db.SaveChangesAsync();
                    }
                    TempData["Notif"] = Notification.ShowNotif(MessageType.Add, type: ToastType.green);
                   
                    return PartialView("_Succefullyresponse", redirecturl);
                }
                else
                {
                    using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                    {
                        string lastupdate = "";
                        model.lastUpdate = lastupdate.GetLastUpdate();
                        model.flag = true;
                        db.Tbl_Setadi.Update(model);
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
                return PartialView("AddEditSetadi", model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteSetadi(int Id)
        {
            var Setadi = new Tbl_Setadi();
            if (Id != 0)
            {
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    Setadi = await _context.Tbl_Setadi.Where(i => i.idSetadi == Id).SingleOrDefaultAsync();
                    if (Setadi == null)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return PartialView("DeleteSetadi", Setadi.edare);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSetadi(int id, string redirecturl)
        {
            if (ModelState.IsValid)
            {
                Tbl_Setadi model = await _context.Tbl_Setadi.Where(i => i.idSetadi == id).SingleOrDefaultAsync();
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    string lastupdate = "";
                    model.lastUpdate = lastupdate.GetLastUpdate();
                    model.flag = false;
                    db.Tbl_Setadi.Update(model);
                    await db.SaveChangesAsync();
                }
                TempData["Notif"] = Notification.ShowNotif(MessageType.Delete, type: ToastType.yellow);
               
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