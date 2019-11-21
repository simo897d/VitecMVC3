using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VitecMVC3.Controllers
{
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