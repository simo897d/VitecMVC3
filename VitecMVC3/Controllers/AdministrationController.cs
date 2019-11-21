using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VitecMVC3.Models;
using VitecMVC3.ViewModels;

namespace VitecMVC3.Controllers {
    public class AdministrationController : Controller {
        private readonly RoleManager<IdentityRole> roleManager;

        public AdministrationController(RoleManager<IdentityRole> _roleManager) {
            _roleManager = roleManager;
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
    }
}
