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
    public class NazarSanji2Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public NazarSanji2Controller(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ClsNavbar clsNavbar = new ClsNavbar(_context);
            NazarSanji2Navbar nazarSanji2Navbar = new NazarSanji2Navbar();

            var select = await _context.NazarSanji2.Where(x => x.flag == true).OrderByDescending(n => n.id).ToListAsync();

            nazarSanji2Navbar.nazarSanji2s = select;
            nazarSanji2Navbar.CommentListNavbar = await clsNavbar.Comment();
            nazarSanji2Navbar.ComplaintsListNavbar = await clsNavbar.Complaint();
            nazarSanji2Navbar.commentcount = nazarSanji2Navbar.CommentListNavbar.Count;
            nazarSanji2Navbar.complaintcount = nazarSanji2Navbar.ComplaintsListNavbar.Count;

            return View(nazarSanji2Navbar);
        }

        public async Task<IActionResult> nazarsanjiSearch(string fromdate1, string todate1)
        {
            ClsNavbar clsNavbar = new ClsNavbar(_context);
            NazarSanji2Navbar nazarSanji2Navbar = new NazarSanji2Navbar();

            var select = await _context.NazarSanji2.Where(x => x.flag == true).OrderByDescending(x => x.id).ToListAsync();


            if (fromdate1 != null && todate1 == null)
            {
                select = select.Where(m => m.ComDate.CompareTo(fromdate1) >= 0).ToList();

            }

            if (todate1 != null && fromdate1 == null)
            {
                select = select.Where(m => m.ComDate.CompareTo(todate1) <= 0).ToList();

            }

            if (fromdate1 != null && todate1 != null)
            {

                select = select.Where(m => m.ComDate.CompareTo(fromdate1) >= 0 && m.ComDate.CompareTo(todate1) <= 0)
                    .ToList();

            }

            nazarSanji2Navbar.nazarSanji2s = select;
            nazarSanji2Navbar.CommentListNavbar = await clsNavbar.Comment();
            nazarSanji2Navbar.ComplaintsListNavbar = await clsNavbar.Complaint();
            nazarSanji2Navbar.commentcount = nazarSanji2Navbar.CommentListNavbar.Count;
            nazarSanji2Navbar.complaintcount = nazarSanji2Navbar.ComplaintsListNavbar.Count;

            return View("Index", nazarSanji2Navbar);
        }

        //[HttpGet]
        //public async Task<IActionResult> AddEditNazarSanji2(int Id)
        //{
        //    var NazarSanji2 = new NazarSanji2();
        //    if (Id != 0)
        //    {
        //        using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
        //        {
        //            NazarSanji2 = await _context.NazarSanji2.Where(c => c.id == Id).SingleOrDefaultAsync();
        //            if (NazarSanji2 == null)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //        }
        //    }
        //    return PartialView("AddEditNazarSanji2", NazarSanji2);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddEditNazarSanji2(NazarSanji2 model, int id, string redirecturl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (id == 0)
        //        {
        //            using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
        //            {

        //                model.flag = true;
        //                db.NazarSanji2.Add(model);
        //                await db.SaveChangesAsync();
        //            }
        //            return PartialView("_Succefullyresponse", redirecturl);
        //        }
        //        else
        //        {
        //            using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
        //            {
        //                model.flag = true;
        //                db.NazarSanji2.Update(model);
        //                await db.SaveChangesAsync();
        //            }
        //            return PartialView("_Succefullyresponse", redirecturl);
        //        }
        //    }
        //    else
        //    {
        //        return PartialView("AddEditNazarSanji2", model);
        //    }
        //}

        [HttpGet]
        public async Task<IActionResult> DeleteNazarSanji2(int Id)
        {
            var NazarSanji2 = new NazarSanji2();
            if (Id != 0)
            {
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    NazarSanji2 = await _context.NazarSanji2.Where(i => i.id == Id).SingleOrDefaultAsync();
                    if (NazarSanji2 == null)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return PartialView("DeleteNazarSanji2", NazarSanji2.hostName);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteNazarSanji2(int id, string redirecturl)
        {
            if (ModelState.IsValid)
            {
                NazarSanji2 model = await _context.NazarSanji2.Where(i => i.id == id).SingleOrDefaultAsync();
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {

                    model.flag = false;

                    db.NazarSanji2.Update(model);
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