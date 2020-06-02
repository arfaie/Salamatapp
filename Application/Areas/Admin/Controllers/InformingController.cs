using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Helpers.OptionEnums;
using Application.Models;
using Application.Models.NavbarModels;
using Application.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Application.Net;
using Application.Net.OptionEnums;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Application.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class InformingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _serviceProvider;
        private readonly IHostingEnvironment _appEnvironmen;
        public InformingController(ApplicationDbContext context, IServiceProvider serviceProvider, IHostingEnvironment appEnvironmen)
        {
            _context = context;
            _serviceProvider = serviceProvider;
            _appEnvironmen = appEnvironmen;
        }

        public async Task<IActionResult> Index()
        {
            ClsNavbar clsNavbar = new ClsNavbar(_context);
            InformingNavbar informingNavbar = new InformingNavbar();
            ViewBag.rootpathe = "/upload/thumbnailimage/";
            List<tbl_Informing> informings = new List<tbl_Informing>();

            var select = await _context.tbl_Informing.Where(x => x.flag == true && x.privatePer == false).ToListAsync();
            foreach (var item in select)
            {
                tbl_Informing _Informing = new tbl_Informing
                {
                    imagename = item.imagename,
                    idInfo = item.idInfo,
                    infoDes = item.infoDes,
                    InfoDateTime = item.InfoDateTime,
                    lastUpdate = item.lastUpdate,
                    privatePer = item.privatePer,
                    flag = item.flag
                };
                informings.Add(_Informing);
            }

            informingNavbar.Informings = informings;
            informingNavbar.CommentListNavbar = await clsNavbar.Comment();
            informingNavbar.ComplaintsListNavbar = await clsNavbar.Complaint();
            informingNavbar.commentcount = informingNavbar.CommentListNavbar.Count;
            informingNavbar.complaintcount = informingNavbar.ComplaintsListNavbar.Count;

            return View(informingNavbar);
        }

        [HttpGet]
        public async Task<IActionResult> AddEditInforming(int Id)
        {
            var Informing = new tbl_Informing();
            if (Id != 0)
            {
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    Informing = await _context.tbl_Informing.Where(i => i.idInfo == Id).SingleOrDefaultAsync();
                    if (Informing == null)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return PartialView("AddEditInforming", Informing);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditInforming(tbl_Informing model, int id, string redirecturl, IEnumerable<IFormFile> files, string Imgename)
        {
            clsTarikh tarix = new clsTarikh();
            if (ModelState.IsValid)
            {
                var uploud = Path.Combine(_appEnvironmen.WebRootPath, "upload\\normalimage\\");
                foreach (var file in files)
                {
                    if (file != null && file.Length > 0)
                    {
                        var filename = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                        using (var fs = new FileStream(Path.Combine(uploud, filename), FileMode.Create))
                        {
                            await file.CopyToAsync(fs);
                            model.imagename = filename;
                        }

                        InsertShowImage.ImageResizer image = new InsertShowImage.ImageResizer();
                        image.Resize(uploud + filename, _appEnvironmen.WebRootPath + "\\upload\\thumbnailimage\\" + filename);

                    }
                }
                if (id == 0)
                {

                    if (model.imagename == null)
                    {
                        model.imagename = "defaultpic.png";
                    }
                    using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                    {
                        string lastupdate = "";
                        model.lastUpdate = lastupdate.GetLastUpdate();
                        model.flag = true;
                        model.privatePer = false;
                        model.InfoDateTime = tarix.date() + " " + "|" + " " + tarix.time();
                        db.tbl_Informing.Add(model);
                        await db.SaveChangesAsync();
                    }

                    TempData["Notif"] = Notification.ShowNotif(MessageType.Add, type: ToastType.green);

                    return PartialView("_Succefullyresponse", redirecturl);

                }
                else
                {
                    if (model.imagename == null)
                    {
                        model.imagename = Imgename;
                    }
                    using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                    {
                        string lastupdate = "";
                        model.lastUpdate = lastupdate.GetLastUpdate();
                        model.flag = true;
                        model.privatePer = false;
                        model.InfoDateTime = tarix.date() + " " + "|" + " " + tarix.time();
                        db.tbl_Informing.Update(model);
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

                return PartialView("AddEditInforming", model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteInforming(int Id)
        {
            var Informing = new tbl_Informing();
            if (Id != 0)
            {
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    Informing = await _context.tbl_Informing.Where(i => i.idInfo == Id).SingleOrDefaultAsync();
                    if (Informing == null)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return PartialView("DeleteInforming", Informing.infoDes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteInforming(int id, string redirecturl)
        {

            if (ModelState.IsValid)
            {

                tbl_Informing model = await _context.tbl_Informing.Where(i => i.idInfo == id).SingleOrDefaultAsync();
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    string lastupdate = "";
                    model.lastUpdate = lastupdate.GetLastUpdate();
                    model.flag = false;
                    db.tbl_Informing.Update(model);
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