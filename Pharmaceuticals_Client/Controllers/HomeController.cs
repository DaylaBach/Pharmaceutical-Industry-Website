using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Pharmaceuticals_Client.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Pharmaceuticals_Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<ActionResult> Index()
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("products");

            var res1 = await response1.Content.ReadAsStringAsync();

            List<Product> prodList = JsonConvert.DeserializeObject<List<Product>>(res1);

            ViewBag.products = prodList;
            ViewBag.products6 = prodList.Take(6);

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("feedbacks");

            var res = await response.Content.ReadAsStringAsync();

            List<Feedback> feedList = JsonConvert.DeserializeObject<List<Feedback>>(res);

            ViewBag.feedback = feedList;

            

           

            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
