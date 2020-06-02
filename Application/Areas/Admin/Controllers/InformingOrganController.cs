using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Application.Helpers.OptionEnums;
using Application.Models;
using Application.Models.NavbarModels;
using Application.Models.ViewModels;
using Application.Net;
using Application.Net.OptionEnums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class InformingOrganController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _serviceProvider;
        private readonly IHostingEnvironment _appEnvironment;

        public InformingOrganController(ApplicationDbContext context, IServiceProvider serviceProvider, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _serviceProvider = serviceProvider;
            _appEnvironment = appEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            ClsNavbar clsNavbar = new ClsNavbar(_context);
            InformingOrganNavbar informingOrganNavbar = new InformingOrganNavbar();

            ViewBag.RootPath = "/upload/InformingOrgan/";
            var select = await _context.tbl_InformingOrgan.Where(x => x.flag == true && x.privatePer == false).ToListAsync();

            informingOrganNavbar.tblInformingOrgans = select;
            informingOrganNavbar.CommentListNavbar = await clsNavbar.Comment();
            informingOrganNavbar.ComplaintsListNavbar = await clsNavbar.Complaint();
            informingOrganNavbar.commentcount = informingOrganNavbar.CommentListNavbar.Count;
            informingOrganNavbar.complaintcount = informingOrganNavbar.ComplaintsListNavbar.Count;

            return View(informingOrganNavbar);
        }

        [HttpGet]
        public async Task<IActionResult> AddEditInformingOrgan(int Id)
        {
            var InformingOrgan = new tbl_InformingOrgan();
            if (Id != 0)
            {
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    InformingOrgan = await _context.tbl_InformingOrgan.Where(i => i.idInfo == Id).SingleOrDefaultAsync();
                    if (InformingOrgan == null)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return PartialView("AddEditInformingOrgan", InformingOrgan);
        }

        public string getname(int id)
        {
            var SelectArzyabi = _context.tbl_Arzyabi.ToList();
            string q = SelectArzyabi.Where(x => x.idArzyabi == id).SingleOrDefault().Arzyabi;
            return q;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditInformingOrgan(tbl_InformingOrgan model, string redirecturl, int id, IEnumerable<IFormFile> files, string Imgname)
        {
            if (ModelState.IsValid)
            {
                //upload audio
                var uploads = Path.Combine(_appEnvironment.WebRootPath, "upload\\InformingOrgan\\");
                bool isfirst = true;
                foreach (var file in files)
                {
                    if (file != null && file.Length > 0)
                    {

                        var filename = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);

                        using (var fs = new FileStream(Path.Combine(uploads, filename), FileMode.Create))
                        {
                            await file.CopyToAsync(fs);
                            if (isfirst)
                            {
                                model.filename1 = filename;
                                isfirst = false;
                            }
                            else
                            {
                                model.filename2 = filename;
                            }

                        }

                    }
                }
                //upload audio
                clsTarikh tarix = new clsTarikh();
                if (id == 0)
                {
                    using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                    {
                        string lastupdate = "";
                        model.lastUpdate = lastupdate.GetLastUpdate();
                        model.flag = true;
                        model.privatePer = false;
                        model.InfoDateTime= tarix.date() + " " + "|" + " " + tarix.time();
                        db.tbl_InformingOrgan.Add(model);
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
                        model.privatePer = false;
                        model.InfoDateTime = tarix.date() + " " + "|" + " " + tarix.time();
                        db.tbl_InformingOrgan.Update(model);
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
                return PartialView("AddEditInformingOrgan", model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteInformingOrgan(int Id)
        {
            var InformingOrgan = new tbl_InformingOrgan();
            if (Id != 0)
            {
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    InformingOrgan = await _context.tbl_InformingOrgan.Where(i => i.idInfo == Id).SingleOrDefaultAsync();
                    if (InformingOrgan == null)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return PartialView("DeleteInformingOrgan", InformingOrgan.infoDes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteInformingOrgan(int id, string redirecturl)
        {
            if (ModelState.IsValid)
            {
                tbl_InformingOrgan model = await _context.tbl_InformingOrgan.Where(i => i.idInfo == id).SingleOrDefaultAsync();
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    string lastupdate = "";
                    model.lastUpdate = lastupdate.GetLastUpdate();
                    model.flag = false;
                    db.tbl_InformingOrgan.Update(model);
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