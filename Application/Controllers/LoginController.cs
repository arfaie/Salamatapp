using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Helpers.OptionEnums;
using Application.Models;
using Application.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Application.Net;
using Application.Net.OptionEnums;

namespace Application.Controllers
{
    public class LoginController : Controller
    {
        

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public LoginController(SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _context = context;
        }

        public ActionResult Login()
        {
           
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async  Task<ActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    //string Comment;
                    //string Complaint;
                    //ClsNavbar clsNavbar = new ClsNavbar(_context);
                    //Comment = JsonConvert.SerializeObject(clsNavbar.Comment()) ?? throw new ArgumentNullException($"JsonConvert.SerializeObject(clsNavbar.Comment())");
                    //Complaint = JsonConvert.SerializeObject(clsNavbar.Complaint()) ?? throw new ArgumentNullException($"JsonConvert.SerializeObject(clsNavbar.Complaint())");
                    //HttpContext.Session.SetString("Comment", Comment);
                    //HttpContext.Session.SetString("Complaint", Complaint);

                    //ClsNavbar clsNavbar = new ClsNavbar(_context);


                    //var select = await _context.View_Comment.Where(x => x.flag == true).ToListAsync();
                    //var select2 = await _context.ViewComplaint.ToListAsync();

                    //CommentComplaintNavbarViewModel navbarViewModel = new CommentComplaintNavbarViewModel();
                    //navbarViewModel.CommentListNavbar =await clsNavbar.Comment();
                    //navbarViewModel.ComplaintsListNavbar =await clsNavbar.Complaint();

                    //وقتی نام کاربری و رمز عبور صحیح باشد
                    return RedirectToAction($"index", $"admin/informing");
                }
                else
                {
                    //وقتی نام کاربری یا رمز عبور صحیح نباشد
                    ModelState.AddModelError(string.Empty, "نام کاربری یا رمز عبور اشتباه است");
                    TempData["Notif"] = Notification.ShowNotif("نام کاربری و یا رمز عبور صحیح نمیباشد", type: ToastType.green);

                    return View(model);
                }
            }
            TempData["Notif"] = Notification.ShowNotif("لطفا نام کاربری و یا رمز عبور را وارد نمایید", type: ToastType.green);

            //وقتی نام کاربری یا رمز عبور خالی باشد
            return View(model);

        }

        public async Task<ActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}