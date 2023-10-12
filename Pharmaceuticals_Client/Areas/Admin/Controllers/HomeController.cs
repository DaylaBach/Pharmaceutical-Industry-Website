using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pharmaceuticals_Client.Areas.Admin.Models;
using Pharmaceuticals_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Pharmaceuticals_Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        [Route("Admin")]
        public async Task<IActionResult> Index()
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res = await response.Content.ReadAsStringAsync();

            AdminViewModel avm = new AdminViewModel();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res);

            return View(avm);
        }

        [Route("Admin/Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Admin/Login")]
        public async Task<IActionResult> Login(string Username, string Password)
        {
            if(Username == null || Password == null)
            {
                ViewBag.Message = "Please provide username and password to login!";
                return Redirect("~/Admin/Login");
            }
            using (var httpClient = new HttpClient())
            {
                var maLog = new Manager();
                maLog.Email = "a";
                maLog.FullName = "b";
                maLog.Username = Username;
                maLog.Password = Password;

                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(maLog), Encoding.UTF8, "application/json");
                using (var response = await GlobalVariables.MyHttpClient.client.PostAsync("token/Manager", stringContent))
                {
                    string token = await response.Content.ReadAsStringAsync();
                    if (token.Contains("Invalid credentials") || token.Contains("Bad Request"))
                    {
                        ViewBag.Message = "Incorrent Username or Password!";
                        return Redirect("~/Admin/Login");
                    }
                    HttpContext.Session.SetString("JWToken", token);
                    HttpContext.Session.SetString("AdminUsername", Username);
                }
                return Redirect("~/Admin");
            }
        }

        [Route("Admin/Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("JWToken"); //clear token
            return Redirect("~/Admin");
        }
    }
}
