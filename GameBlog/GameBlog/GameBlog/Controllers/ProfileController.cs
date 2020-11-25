using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GameBlog.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GameBlog.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private ApplicationUserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
        }

        private ApplicationRoleManager RoleManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<ApplicationRoleManager>(); }
        }
        // GET: Profile
        public async Task<ActionResult> Home()
        {
            var userData = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var roleData = await UserManager.GetRolesAsync(userData.Id);
            ProfileModel profileModel = new ProfileModel { UserName = userData.UserName, Email = userData.Email, Role = roleData };
            return View(profileModel);
        }

        public async Task<ActionResult> Edit()
        {
            ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                EditUserViewModel model = new EditUserViewModel
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    Year = user.Year
                };
                return View(model);
            }
            return RedirectToAction("Login","Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditUserViewModel model)
        {
            ApplicationUser user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.Year = model.Year;
                IdentityResult result = await UserManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Home", "Profile");
                }
                else
                {
                    ModelState.AddModelError("", "Что-то пошло не так");
                }
            }
            else
            {
                ModelState.AddModelError("","Пользователь не найден");
            }
            return View(model);
        }
    }
}