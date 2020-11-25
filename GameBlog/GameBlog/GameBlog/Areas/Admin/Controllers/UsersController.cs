using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using GameBlog.Models;
using GameBlog.Areas.Admin.Models;
using System.Data.Entity;
using System.Threading.Tasks;
namespace GameBlog.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private ApplicationUserManager userManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
        }

        private ApplicationContext db;

        // GET: Admin/Users
        public async Task<ActionResult> Index()
        {
            IEnumerable<ApplicationUser> user = await userManager.Users.ToListAsync();
            IEnumerable<UsersIndexViewModel> model = user.Select(x => new UsersIndexViewModel
            {
                Id = x.Id,
                Email = x.Email,
                Role = userManager.GetRoles(x.Id),
                UserName = x.UserName
            });
            
            return View(model);
        }

        public ActionResult CreateUser()
        {
            db = new ApplicationContext();
            CreateViewBagRolesList(db);
            return View();
        }

        private void CreateViewBagRolesList(ApplicationContext db)
        {
            SelectList roles = new SelectList(db.Roles, "Id", "Name");
            ViewBag.Roles = roles;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateUser(CreateUserViewModel model)
        {
            db = new ApplicationContext();
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Year = model.Year,
                    Email = model.Email,                   
                };

                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var role = await db.Roles.Where(x => x.Id == model.RoleId.ToString()).FirstOrDefaultAsync();
                    await userManager.AddToRoleAsync(user.Id, role.Name.ToString());
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError("",err);
                    }
                }
            }

            CreateViewBagRolesList(db);
            return View(model);
        }

        public async Task<ActionResult> Update(string id)
        {
            db = new ApplicationContext();
            UserUpdateViewModel model;
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return RedirectToAction("Index");
            }

            model = new UserUpdateViewModel
            {
                Id = user.Id,
                Email = user.Email,
                RoleId = user.Roles.FirstOrDefault().RoleId,
                UserName = user.UserName,
                Year = user.Year
            };

            CreateViewBagRolesList(db);
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(UserUpdateViewModel model)
        {            
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    db = new ApplicationContext();
                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    user.Year = model.Year;
                    var result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        var userRoleId = user.Roles.FirstOrDefault().RoleId;
                        if (userRoleId != model.RoleId)
                        {
                            await userManager.RemoveFromRoleAsync(user.Id, db.Roles.Where(x => x.Id == userRoleId).FirstOrDefault().Name);
                            await userManager.AddToRoleAsync(user.Id, db.Roles.Where(x => x.Id == model.RoleId).FirstOrDefault().Name);
                        }
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var err in result.Errors)
                        {
                            ModelState.AddModelError("", err);
                        }
                    }
                }              
            }
            CreateViewBagRolesList(db);
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            ApplicationUser user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            return View(new UserDeleteViewModel {Id = user.Id,Email = user.Email,UserName = user.UserName});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirm(UserDeleteViewModel model)
        {
            ApplicationUser user = await userManager.FindByIdAsync(model.Id);
            if (user != null)
            {
                await userManager.DeleteAsync(user);
              
            }
            return RedirectToAction("Index");           
        }
    }
}