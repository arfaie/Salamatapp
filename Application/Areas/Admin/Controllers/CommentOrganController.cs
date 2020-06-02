using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Models;
using Application.Models.NavbarModels;
using Application.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CommentOrganController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public CommentOrganController(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public async Task<IActionResult> Index()
        {
            

            ClsNavbar clsNavbar = new ClsNavbar(_context);
            CommentOrganNavbar commentOrganNavbar = new CommentOrganNavbar();

            var select = await _context.tbl_CommentOrgan.Where(x => x.flag == true).ToListAsync();

            commentOrganNavbar.tblCommentOrgans = select;
            commentOrganNavbar.CommentListNavbar = await clsNavbar.Comment();
            commentOrganNavbar.ComplaintsListNavbar = await clsNavbar.Complaint();
            commentOrganNavbar.commentcount = commentOrganNavbar.CommentListNavbar.Count;
            commentOrganNavbar.complaintcount = commentOrganNavbar.ComplaintsListNavbar.Count;

            return View(commentOrganNavbar);
        }

        //[HttpGet]
        //public async Task<IActionResult> AddEditCommentOrgan(int Id)
        //{
        //    var CommentOrgan = new tbl_CommentOrgan();
        //    if (Id != 0)
        //    {
        //        using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
        //        {
        //            CommentOrgan = await _context.tbl_CommentOrgan.Where(c => c.idComment == Id).SingleOrDefaultAsync();
        //            if (CommentOrgan == null)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //        }
        //    }
        //    return PartialView("AddEditCommentOrgan", CommentOrgan);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> AddEditCommentOrgan(tbl_CommentOrgan model, int id, string redirecturl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (id == 0)
        //        {
        //            using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
        //            {
        //                model.flag = true;
        //                db.tbl_CommentOrgan.Add(model);
        //                await db.SaveChangesAsync();
        //            }
        //            return PartialView("_Succefullyresponse", redirecturl);
        //        }
        //        else
        //        {
        //            using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
        //            {
        //                model.flag = true;
        //                db.tbl_CommentOrgan.Update(model);
        //                await db.SaveChangesAsync();
        //            }
        //            return PartialView("_Succefullyresponse", redirecturl);
        //        }
        //    }
        //    else
        //    {
        //        return PartialView("AddEditCommentOrgan", model);
        //    }
        //}

        //[HttpGet]
        //public async Task<IActionResult> DeleteCommentOrgan(int Id)
        //{
        //    var CommentOrgan = new tbl_CommentOrgan();
        //    if (Id != 0)
        //    {
        //        using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
        //        {
        //            CommentOrgan = await _context.tbl_CommentOrgan.Where(i => i.idComment == Id).SingleOrDefaultAsync();
        //            if (CommentOrgan == null)
        //            {
        //                return RedirectToAction("Index");
        //            }
        //        }
        //    }
        //    return PartialView("DeleteCommentOrgan", CommentOrgan.CommentText);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteCommentOrgan(tbl_CommentOrgan model, int id, string redirecturl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        model = await _context.tbl_CommentOrgan.Where(i => i.idComment == id).SingleOrDefaultAsync();
        //        using (var db = _serviceProvider.GetRequiredService<ApplicationDbContext>())
        //        {

        //            model.flag = false;
        //            db.tbl_CommentOrgan.Update(model);
        //            await db.SaveChangesAsync();
        //        }
        //        return PartialView("_Succefullyresponse", redirecturl);
        //    }
        //    else
        //    {
        //        return PartialView("DeleteCommentOrgan", model);
        //    }
        //}
    }
}