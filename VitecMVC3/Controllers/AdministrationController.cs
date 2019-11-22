using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VitecMVC3.Models;
using VitecMVC3.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace VitecMVC3.Controllers {
    [Authorize(Roles = "Administrator")]
    public class AdministrationController : Controller {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AdministrationController(RoleManager<IdentityRole> _roleManager,
                                        UserManager<ApplicationUser> _userManager) {
            roleManager = _roleManager;
            userManager = _userManager;
        }
        [HttpGet]
        public IActionResult CreateRole() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model) {
            if (ModelState.IsValid) {
                IdentityRole identityRole = new IdentityRole {
                    Name = model.RoleName
                };
                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded) {
                    return RedirectToAction("index", "home");
                }
                foreach (IdentityError error in result.Errors) {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult ListRoles() {
            var roles = roleManager.Roles;
            return View(roles);
        }

        #region EditRole Get and Post
        [HttpGet]
        public async Task<IActionResult> EditRole(string id) {
            var role = await roleManager.FindByIdAsync(id);

            if(role == null) {
                ViewBag.ErrorMessage = "Error";
                return View("Error");
            }

            var model = new EditRoleViewModel {
                Id = role.Id,
                RoleName = role.Name,

            };

            foreach (var user in userManager.Users) {
                if(await userManager.IsInRoleAsync(user, role.Name)) {
                    model.Users.Add(user.UserName);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model) {
            var role = await roleManager.FindByIdAsync(model.Id);

            if (role == null) {
                ViewBag.ErrorMessage = "Error";
                return View("Error");
            }
            else{
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded) {
                    return RedirectToAction("ListRoles");
                }
                foreach (var error in result.Errors) {

                }
                return View(model);
            }
        }
        #endregion
        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId) {
            ViewBag.roleId = roleId;

            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null) {
                ViewBag.ErrorMessage = "Error";
                return View("Error");
            }
            var model = new List<UserRoleViewModel>();

            foreach (var user in userManager.Users) {
                var userRoleViewModel = new UserRoleViewModel {
                    UserId = user.Id,
                    UserName = user.UserName
                };
                if (await userManager.IsInRoleAsync(user, role.Name)) {
                    userRoleViewModel.IsSelected = true;
                } else {
                    userRoleViewModel.IsSelected = false;
                }

                model.Add(userRoleViewModel);
            }

            return View(model);

        }
    }
}
