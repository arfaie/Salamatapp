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
    public class PersonalController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public PersonalController(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public async Task<IActionResult> Index()
        {
            ClsNavbar clsNavbar = new ClsNavbar(_context);
            PersonalNavbar personalNavbar = new PersonalNavbar();


            var select = await _context.TblPersonal.ToListAsync();

            personalNavbar.tblPersonals = select;
            personalNavbar.CommentListNavbar = await clsNavbar.Comment();
            personalNavbar.ComplaintsListNavbar = await clsNavbar.Complaint();
            personalNavbar.commentcount = personalNavbar.CommentListNavbar.Count;
            personalNavbar.complaintcount = personalNavbar.ComplaintsListNavbar.Count;

            return View(personalNavbar);
        }

        [HttpGet]
        public async Task<IActionResult> AddEditPersonal(int Id)
        {
            var Personal = new TblPersonal();
            if (Id != 0)
            {
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    Personal = await _context.TblPersonal.Where(c => c.idPerson == Id).SingleOrDefaultAsync();
                    if (Personal == null)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return PartialView("AddEditPersonal", Personal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditPersonal(TblPersonal model, int id, string redirecturl)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                    {                                            
                        db.TblPersonal.Add(model);
                        await db.SaveChangesAsync();
                    }
                    TempData["Notif"] = Notification.ShowNotif(MessageType.Add, type: ToastType.green);
                    return PartialView("_Succefullyresponse", redirecturl);
                }
                else
                {
                    using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                    {                      
                        db.TblPersonal.Update(model);
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
                return PartialView("AddEditPersonal", model);
            }
        }
    }
}