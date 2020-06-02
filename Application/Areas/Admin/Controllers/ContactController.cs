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
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public ContactController(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ClsNavbar clsNavbar = new ClsNavbar(_context);
            ContactNavbar contactNavbar = new ContactNavbar();

            var select = await _context.tbl_Contact.ToListAsync();

            contactNavbar.tblContacts = select;
            contactNavbar.CommentListNavbar = await clsNavbar.Comment();
            contactNavbar.ComplaintsListNavbar = await clsNavbar.Complaint();
            contactNavbar.commentcount = contactNavbar.CommentListNavbar.Count;
            contactNavbar.complaintcount = contactNavbar.ComplaintsListNavbar.Count;

            return View(contactNavbar);
        }

        [HttpGet]
        public async Task<IActionResult> AddEditContact(int Id)
        {
            var Contact = new tbl_Contact();
            if (Id != 0)
            {
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    Contact = await _context.tbl_Contact.Where(c => c.idContact == Id).SingleOrDefaultAsync();
                    if (Contact == null)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return PartialView("AddEditContact", Contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditContact(tbl_Contact model, int id, string redirecturl)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                    {
                        string lastupdate = "";
                        model.lastUpdate = lastupdate.GetLastUpdate();
                        db.tbl_Contact.Add(model);
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
                        db.tbl_Contact.Update(model);
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
                   TempData["Notif"] = Notification.ShowNotif(MessageType.Edit, type: ToastType.yellow);
                }
                return PartialView("AddEditContact", model);
            }
        }

       
    }
}