using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VitecMVC3.Models;

namespace VitecMVC3.Controllers
{
    [Authorize(Roles = "User,Admin,Administrator")]
    public class UserDashboardController : Controller
    {
        public IActionResult Index() {

            return View();
        }
        [AllowAnonymous]
        public IActionResult BuySubscriptionPage() {
            using (HttpClient client = new HttpClient()) {

                HttpResponseMessage response = client.GetAsync("http://egebjerg.it/api/subscription").Result;
                response.EnsureSuccessStatusCode();
                var responseBody = response.Content.ReadAsStringAsync().Result;

                var model = JsonConvert.DeserializeObject<List<Subscription>>(responseBody);
                return View(model);
            }
        }
        [AllowAnonymous]
        public IActionResult PurchaseSubscription() {
            return View();
        }
    }
}