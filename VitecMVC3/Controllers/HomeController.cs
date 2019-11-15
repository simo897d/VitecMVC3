using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VitecMVC3.Models;
using Microsoft.AspNetCore.Identity;

namespace VitecMVC3.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index() {
            using (HttpClient client = new HttpClient()) {

                HttpResponseMessage response = client.GetAsync("https://localhost:44388/api/products").Result;
                response.EnsureSuccessStatusCode();
                var responseBody = response.Content.ReadAsStringAsync().Result;

                var model = JsonConvert.DeserializeObject<List<Products>>(responseBody);
                return View(model);
            }
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
