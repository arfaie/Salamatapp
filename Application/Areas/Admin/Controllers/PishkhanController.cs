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
    public class PishkhanController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public PishkhanController(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public async Task<IActionResult> Index()
        {
            ClsNavbar clsNavbar = new ClsNavbar(_context);
            PishkhanNavbar pishkhanNavbar = new PishkhanNavbar();

            var select = await _context.Tbl_Pishkhan.Where(x => x.flag == true).ToListAsync();

            pishkhanNavbar.tblPishkhans = select;
            pishkhanNavbar.CommentListNavbar = await clsNavbar.Comment();
            pishkhanNavbar.ComplaintsListNavbar = await clsNavbar.Complaint();
            pishkhanNavbar.commentcount = pishkhanNavbar.CommentListNavbar.Count;
            pishkhanNavbar.complaintcount = pishkhanNavbar.ComplaintsListNavbar.Count;

            return View(pishkhanNavbar);
        }

        [HttpGet]
        public async Task<IActionResult> AddEditPishkhan(int Id)
        {
            var Pishkhan = new Tbl_Pishkhan();
            if (Id != 0)
            {
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    Pishkhan = await _context.Tbl_Pishkhan.Where(i => i.idPishkhan == Id).SingleOrDefaultAsync();
                    if (Pishkhan == null)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return PartialView("AddEditPishkhan", Pishkhan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditPishkhan(Tbl_Pishkhan model, int id, string redirecturl)
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
                        db.Tbl_Pishkhan.Add(model);
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
                        db.Tbl_Pishkhan.Update(model);
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
                return PartialView("AddEditPishkhan", model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeletePishkhan(int Id)
        {
            var Pishkhan = new Tbl_Pishkhan();
            if (Id != 0)
            {
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    Pishkhan = await _context.Tbl_Pishkhan.Where(i => i.idPishkhan == Id).SingleOrDefaultAsync();
                    if (Pishkhan == null)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
           
            return PartialView("DeletePishkhan", Pishkhan.code);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePishkhan(int id, string redirecturl)
        {
            if (ModelState.IsValid)
            {
                Tbl_Pishkhan model = await _context.Tbl_Pishkhan.Where(i => i.idPishkhan == id).SingleOrDefaultAsync();
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    string lastupdate = "";
                    model.lastUpdate = lastupdate.GetLastUpdate();
                    model.flag = false;
                    db.Tbl_Pishkhan.Update(model);
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