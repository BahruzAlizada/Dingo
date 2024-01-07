using Dingo.ViewModels;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dingo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Superadmin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager )
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            List<AppUser> users = await userManager.Users.ToListAsync();
            List<UserVM> usersVM = new List<UserVM>();

            foreach (var item in users)
            {
                UserVM vM = new UserVM
                {
                    Id = item.Id,
                    Email = item.Email,
                    UserName = item.UserName,
                    Role = (await userManager.GetRolesAsync(item))[0],
                    IsDeactive = item.IsDeacive
                };
                usersVM.Add(vM);
            }
            return View(usersVM);
        }
        #endregion

        #region Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Roles = await roleManager.Roles.ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(RegisterVM register, int roleId)
        {
            ViewBag.Roles = await roleManager.Roles.ToListAsync();
            AppRole? role = await roleManager.Roles.FirstOrDefaultAsync(x => x.Id == roleId);
            if(role==null) return BadRequest(); 


            AppUser user = new AppUser
            {
                UserName = register.UserName,
                Email = register.Email,
                IsDeacive = false
            };

            IdentityResult result = await userManager.CreateAsync(user, register.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            await userManager.AddToRoleAsync(user, role.Name);

            return RedirectToAction("Index");
        }

        #endregion

        #region Update
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            AppUser? user = await userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return BadRequest();

            UserVM dbUserVM = new UserVM
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                IsDeactive = user.IsDeacive
            };

            return View(dbUserVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Update(int? id, UserVM newUserVM)
        {
            #region Get
            if (id == null) return NotFound();
            AppUser? user = await userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return BadRequest();

            UserVM dbUserVM = new UserVM
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                IsDeactive = user.IsDeacive
            };
            #endregion

            user.Id = newUserVM.Id;
            user.UserName = newUserVM.UserName;
            user.Email = newUserVM.Email;
            user.IsDeacive = newUserVM.IsDeactive;

            await userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }
        #endregion

        #region ResetPassword
        public async Task<IActionResult> ResetPassword(int? id)
        {
            if (id == null) return NotFound();
            AppUser? user = await userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return BadRequest();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ResetPassword(int? id, ResetPasswordVM resetPassword)
        {
            if (id == null) return NotFound();
            AppUser? user = await userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return BadRequest();

            string token = await userManager.GeneratePasswordResetTokenAsync(user);

            IdentityResult result = await userManager.ResetPasswordAsync(user, token, resetPassword.NewPassword);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region RoleChange
        public async Task<IActionResult> RoleChange(int? id)
        {
            if (id == null) return NotFound();
            AppUser? user = await userManager.Users.FirstOrDefaultAsync(x=>x.Id==id);
            if (user == null) return BadRequest();

            ViewBag.Roles = await roleManager.Roles.Select(x => x.Name).ToListAsync();

            RoleVM roleVM = new RoleVM
            {
                Role = (await userManager.GetRolesAsync(user))[0]
            };

            return View(roleVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> RoleChange(int? id, string role)
        {
            if (id == null) return NotFound();
            AppUser? user = await userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return BadRequest();

            ViewBag.Roles = await roleManager.Roles.Select(x => x.Name).ToListAsync();

            RoleVM roleVM = new RoleVM
            {
                Role = (await userManager.GetRolesAsync(user))[0]
            };

            await userManager.RemoveFromRoleAsync(user, roleVM.Role);
            await userManager.AddToRoleAsync(user, role);

            return RedirectToAction("Index");
        }
        #endregion

        #region Activity
        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null) return NotFound();
            AppUser? user = await userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return BadRequest();

            if (user.IsDeacive)
                user.IsDeacive = false;
            else
                user.IsDeacive = true;

            await userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            AppUser? user = await userManager.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return BadRequest();

            await userManager.DeleteAsync(user);
            return RedirectToAction("Index");
        }
        #endregion

    }
}
