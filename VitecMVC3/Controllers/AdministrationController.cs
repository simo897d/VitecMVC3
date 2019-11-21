﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VitecMVC3.Models;

namespace VitecMVC3.Controllers {
    public class AdministrationController : Controller {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager) {
            _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult CreateRole() {
            return View();
        }

    }
}
