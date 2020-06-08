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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Application.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, ApplicationDbContext context, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ClsNavbar clsNavbar = new ClsNavbar(_context);
            UserNavbar userNavbar = new UserNavbar();

            List<UserListViewModel> model = new List<UserListViewModel>();
            model = await _userManager.Users.Select(u => new UserListViewModel
            {
                Id = u.Id,
                FullName = u.FirstName + " " + u.LastName,
                Email = u.Email
            }).ToListAsync();

            userNavbar.userListViewModels = model;
            userNavbar.CommentListNavbar = await clsNavbar.Comment();
            userNavbar.ComplaintsListNavbar = await clsNavbar.Complaint();

            userNavbar.commentcount = userNavbar.CommentListNavbar.Count;
            userNavbar.complaintcount = userNavbar.ComplaintsListNavbar.Count;

            return View(userNavbar);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            UserViewModel model = new UserViewModel();
            model.ApplicationRoles = _roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id

            }).ToList();


            return PartialView("AddUser", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(UserViewModel model, string redirecturl)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    UserName = model.Username,
                    Email = model.Email
                };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    ApplicationRole approle = await _roleManager.FindByIdAsync(model.ApplicationRoleId);
                    if (approle != null)
                    {
                        IdentityResult Roleresult = await _userManager.AddToRoleAsync(user, approle.Name);
                        if (Roleresult.Succeeded)
                        {
                            TempData["Notif"] = Notification.ShowNotif(MessageType.Add, type: ToastType.green);

                            return PartialView("_Succefullyresponse", redirecturl);
                        }
                    }
                }
            }

            model.ApplicationRoles = _roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id

            }).ToList();
            return PartialView("AddUser", model);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string Id)
        {
            EditUserViewModel model = new EditUserViewModel();
            model.ApplicationRoles = _roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id
            }).ToList();
            /////////////////////////////////////////////////////////
            if (!string.IsNullOrEmpty(Id))
            {
                //ApplicationUser user = new ApplicationUser();
                ApplicationUser user = await _userManager.FindByIdAsync(Id);
                if (user != null)
                {
                    model.FirstName = user.FirstName;
                    model.LastName = user.LastName;
                    model.Email = user.Email;
                    model.Username = user.UserName;

                    model.ApplicationRoleId = _roleManager.Roles.Single(r => r.Name == _userManager.GetRolesAsync(user).Result.Single()).Id;
                }
            }

            return PartialView("EditUser", model);
        }

        //[HttpPost]
        ////[ValidateAntiForgeryToken]
        //public async Task<IActionResult> EditUser(string id, EditUserViewModel model, string redirecturl)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ApplicationUser user = await _userManager.FindByIdAsync(id);
        //        if (user != null)
        //        {
        //            user.FirstName = model.FirstName;
        //            user.LastName = model.LastName;
        //            user.Email = model.Email;
        //            //user.UserName = model.Username;


        //            string existingRole = _userManager.GetRolesAsync(user).Result.Single();
        //            string exiistingRoleId = _roleManager.Roles.Single(r => r.Name == existingRole).Id;
        //            IdentityResult result = await _userManager.UpdateAsync(user);
        //            if (result.Succeeded)
        //            {
        //                if (exiistingRoleId != model.ApplicationRoleId)
        //                {
        //                    IdentityResult roleresult = await _userManager.RemoveFromRoleAsync(user, existingRole);
        //                    if (roleresult.Succeeded)
        //                    {
        //                        ApplicationRole applicationRole = await _roleManager.FindByIdAsync(model.ApplicationRoleId);
        //                        if (applicationRole != null)
        //                        {
        //                            IdentityResult newrole = await _userManager.AddToRoleAsync(user, applicationRole.Name);
        //                            if (newrole.Succeeded)
        //                            {
        //                                TempData["Notif"] = Notification.ShowNotif(MessageType.Edit, type: ToastType.blue);

        //                                return PartialView("_Succefullyresponse", redirecturl);
        //                            }
        //                        }
        //                    }
        //                }
        //                TempData["Notif"] = Notification.ShowNotif(MessageType.Edit, type: ToastType.blue);

        //                return PartialView("_Succefullyresponse", redirecturl);
        //            }
        //        }
        //    }

        //    model.ApplicationRoles = _roleManager.Roles.Select(r => new SelectListItem
        //    {
        //        Text = r.Name,
        //        Value = r.Id

        //    }).ToList();

        //    return PartialView("EditUser", model);

        //}

        //////////////////////////////////////////////////////////////////////////////////////////////
        ///
        [HttpPost]
        public async Task<IActionResult> EditUser(string id, EditUserViewModel model, string redirecturl)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);

                if (user == null)
                {
                    ViewBag.Error = $"User Not Found";
                    return RedirectToAction("Index");
                }
                else
                {
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Email = model.Email;
                    user.UserName = model.Username;

                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        return PartialView("_Succefullyresponse", redirecturl);
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model);
                }
            }
            catch
            {
                return View(model);
            }

           
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(string id, ChangePasswordViewModel model, string redirecturl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return RedirectToAction("Index");
                }

                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

                if (!result.Succeeded)
                {

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View();
                }

                await _signInManager.RefreshSignInAsync(user);
                return PartialView("_Succefullyresponse", redirecturl);

            }
            return View();
        }

    }
}