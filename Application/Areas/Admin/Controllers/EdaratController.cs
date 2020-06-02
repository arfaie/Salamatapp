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
    public class EdaratController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public EdaratController(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public async Task<IActionResult> Index()
        {
            ClsNavbar clsNavbar = new ClsNavbar(_context);
            EdaratNavbar edaratNavbar = new EdaratNavbar();

            var select = await _context.Tbl_Edarat.Where(x => x.flag == true).ToListAsync();

            edaratNavbar.tblEdarats = select;
            edaratNavbar.CommentListNavbar = await clsNavbar.Comment();
            edaratNavbar.ComplaintsListNavbar = await clsNavbar.Complaint();
            edaratNavbar.commentcount = edaratNavbar.CommentListNavbar.Count;
            edaratNavbar.complaintcount = edaratNavbar.ComplaintsListNavbar.Count;

            return View(edaratNavbar);
        }

        [HttpGet]
        public async Task<IActionResult> AddEditEdarat(int Id)
        {
            var Edarat = new Tbl_Edarat();
            if (Id != 0)
            {
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    Edarat = await _context.Tbl_Edarat.Where(i => i.idOffice == Id).SingleOrDefaultAsync();
                    if (Edarat == null)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return PartialView("AddEditEdarat", Edarat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditEdarat(Tbl_Edarat model, int id, string redirecturl)
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
                        db.Tbl_Edarat.Add(model);
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
                        db.Tbl_Edarat.Update(model);
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
                return PartialView("AddEditEdarat", model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteEdarat(int Id)
        {
            var Edarat = new Tbl_Edarat();
            if (Id != 0)
            {
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    Edarat = await _context.Tbl_Edarat.Where(i => i.idOffice == Id).SingleOrDefaultAsync();
                    if (Edarat == null)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return PartialView("DeleteEdarat", Edarat.admin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEdarat(int id, string redirecturl)
        {
            if (ModelState.IsValid)
            {
                Tbl_Edarat model = await _context.Tbl_Edarat.Where(i => i.idOffice == id).SingleOrDefaultAsync();
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    string lastupdate = "";
                    model.lastUpdate = lastupdate.GetLastUpdate();
                    model.flag = false;
                    db.Tbl_Edarat.Update(model);
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