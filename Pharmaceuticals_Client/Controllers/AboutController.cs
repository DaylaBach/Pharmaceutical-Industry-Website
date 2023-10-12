using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pharmaceuticals_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Pharmaceuticals_Client.Controllers
{
    public class AboutController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("feedbacks");

            var res = await response.Content.ReadAsStringAsync();

            List<Feedback> feedList = JsonConvert.DeserializeObject<List<Feedback>>(res);

            ViewBag.feedback = feedList;

            return View();
        }
    }
}
