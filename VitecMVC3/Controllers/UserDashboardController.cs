using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VitecMVC3.Controllers
{
    [Authorize(Roles = "User,Admin,Administrator")]
    public class UserDashboardController : Controller
    {
        public IActionResult Index()
        {
           
            return View();
        }
        public IActionResult BuySubscriptionPage() {
            return View();
        }
    }
}