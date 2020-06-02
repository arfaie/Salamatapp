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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class InstitutionController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public InstitutionController(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public async Task<IActionResult> Index()
        {
            ClsNavbar clsNavbar = new ClsNavbar(_context);
            InstitutionNavbar institutionNavbar = new InstitutionNavbar();

            var select = await _context.View_NewInstitutes.Where(x => x.flag == true).ToListAsync();

            institutionNavbar.viewNewInstituteses = select;
            institutionNavbar.CommentListNavbar = await clsNavbar.Comment();
            institutionNavbar.ComplaintsListNavbar = await clsNavbar.Complaint();
            institutionNavbar.commentcount = institutionNavbar.CommentListNavbar.Count;
            institutionNavbar.complaintcount = institutionNavbar.ComplaintsListNavbar.Count;

            return View(institutionNavbar);
        }

        [HttpGet]
        public async Task<IActionResult> AddEditInstitution(int id)
        {
            TblINSTITUTE_ViewModel model = new TblINSTITUTE_ViewModel();
            model.Cites = await _context.TblCity_.Select(bg => new SelectListItem
            {
                Text = bg.CityName,
                Value = bg.idCity.ToString()

            }).ToListAsync();


            model.Owners = await _context.TblOwner_.Select(a => new SelectListItem
            {
                Text = a.OwnerName,
                Value = a.idOwner.ToString()
            }).ToListAsync();

            model.Institute_Types = await _context.TblINSTITUTE_TYPE_.Select(a => new SelectListItem
            {
                Text = a.INSTITUTE_TYPE,
                Value = a.idINSTITUTE_TYPE.ToString()
            }).ToListAsync();

            if (id != 0)
            {
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    TblINSTITUTE_ iNSTITUTE_ = await _context.TblINSTITUTE_.Where(b => b.idInstitues == id).SingleOrDefaultAsync();
                    if (iNSTITUTE_ != null)
                    {
                        model.idInstitues = iNSTITUTE_.idInstitues;
                        model.codeOrgan = iNSTITUTE_.codeOrgan;
                        model.nameOrgan = iNSTITUTE_.nameOrgan;
                        model.nameOrganMain = iNSTITUTE_.nameOrganMain;
                        model.hos = iNSTITUTE_.hos;
                        model.idINSTITUTE_TYPE = iNSTITUTE_.idINSTITUTE_TYPE;
                        model.idowner = iNSTITUTE_.idowner;
                        model.idCity = iNSTITUTE_.idCity;
                        model.ADDRESS = iNSTITUTE_.ADDRESS;
                        model.TEL = iNSTITUTE_.TEL;
                        model.fax = iNSTITUTE_.fax;
                        model.email = iNSTITUTE_.email;
                        model.mobile = iNSTITUTE_.mobile;
                        model.lastUpdate = iNSTITUTE_.lastUpdate;
                        model.flag = iNSTITUTE_.flag;

                    }
                }
            }

            return PartialView("AddEditInstitution", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEditInstitution(TblINSTITUTE_ViewModel model, int id, string redirecturl)
        {
            if (ModelState.IsValid)
            {
                string LastUpdate = "";

                if (id == 0)
                {
                    
                    //insert
                    using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                    {
                        TblINSTITUTE_ INSTITUTE_model = AutoMapper.Mapper.Map<TblINSTITUTE_ViewModel, TblINSTITUTE_>(model);
                        model.lastUpdate = LastUpdate.GetLastUpdate();
                        model.flag = true;
                        db.TblINSTITUTE_.Add(INSTITUTE_model);
                        await db.SaveChangesAsync();
                    }
                    TempData["Notif"] = Notification.ShowNotif(MessageType.Add, type: ToastType.green);

                    return PartialView("_Succefullyresponse", redirecturl);
                }
                else
                {
                    //update
                    using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                    {
                        TblINSTITUTE_ INSTITUTE_model = AutoMapper.Mapper.Map<TblINSTITUTE_ViewModel, TblINSTITUTE_>(model);
                        model.lastUpdate = LastUpdate.GetLastUpdate();
                        model.flag = true;
                        db.TblINSTITUTE_.Update(INSTITUTE_model);
                        await db.SaveChangesAsync();
                    }
                    TempData["Notif"] = Notification.ShowNotif(MessageType.Edit, type: ToastType.blue);

                    return PartialView("_Succefullyresponse", redirecturl);
                }
            }

            model.Cites = await _context.TblCity_.Select(bg => new SelectListItem
            {
                Text = bg.CityName,
                Value = bg.idCity.ToString()

            }).ToListAsync();


            model.Owners = await _context.TblOwner_.Select(a => new SelectListItem
            {
                Text = a.OwnerName,
                Value = a.idOwner.ToString()
            }).ToListAsync();

            model.Institute_Types = await _context.TblINSTITUTE_TYPE_.Select(a => new SelectListItem
            {
                Text = a.INSTITUTE_TYPE,
                Value = a.idINSTITUTE_TYPE.ToString()
            }).ToListAsync();

            if (id == 0)
            {
                TempData["Notif"] = Notification.ShowNotif(MessageType.addError, type: ToastType.yellow);
            }
            else
            {
                TempData["Notif"] = Notification.ShowNotif(MessageType.editError, type: ToastType.yellow);
            }

            return PartialView("AddEditInstitution", model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteInstitution(int Id)
        {
            
            var Institution = new TblINSTITUTE_();
            if (Id != 0)
            {
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    Institution = await _context.TblINSTITUTE_.Where(i => i.idInstitues == Id).SingleOrDefaultAsync();
                    if (Institution == null)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return PartialView("DeleteInstitution", Institution.nameOrgan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteInstitution(int id, string redirecturl)
        {
            if (ModelState.IsValid)
            {
                string LastUpdate = "";
                TblINSTITUTE_ model = await _context.TblINSTITUTE_.Where(i => i.idInstitues == id).SingleOrDefaultAsync();
                using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    model.lastUpdate = LastUpdate.GetLastUpdate();
                    model.flag = false;
                    db.TblINSTITUTE_.Update(model);
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