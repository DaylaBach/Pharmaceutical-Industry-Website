using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pharmaceuticals_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Pharmaceuticals_Client.Controllers
{
    public class QuoteUsController : Controller
    {
        bool IsDuplicate;

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Feedback f)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            if (ModelState.IsValid)
            {
                f.Created_date = DateTime.Now;

                IsDuplicate = checkNameDuplicateAsync(f.FullName, 0).Result;

                if (IsDuplicate)
                {
                    ModelState.AddModelError("FullName", "Feedback existed.");
                    return View(f);
                }

                var result = await GlobalVariables.MyHttpClient.client
                    .PostAsync("feedbacks", new StringContent(JsonConvert.SerializeObject(f), Encoding.UTF8, "application/json"));

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Successfully");
                }

            }
            return View(f);
        }

        public async Task<bool> checkNameDuplicateAsync(string name, int id)
        {
            var response = await GlobalVariables.MyHttpClient.client.GetAsync("feedbacks");

            var res = await response.Content.ReadAsStringAsync();

            List<Feedback> feedbackList = JsonConvert.DeserializeObject<List<Feedback>>(res);
            foreach (var f in feedbackList)
            {
                if (name.Equals(f.FullName) && f.FeedbackId.Equals(id))
                {
                    continue;
                }
                if (name.Equals(f.FullName))
                {
                    return true;
                }
            }

            return false;
        }

        public IActionResult Successfully()
        {
            return View();
        }
    }
}
