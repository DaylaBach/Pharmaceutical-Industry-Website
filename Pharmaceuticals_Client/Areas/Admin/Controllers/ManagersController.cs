using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Pharmaceuticals_Client.Areas.Admin.Models;
using Pharmaceuticals_Client.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Pharmaceuticals_Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManagersController : Controller
    {
        int Limit = 2;

        [Route("Admin/Managers")]
        public async Task<ActionResult> Index(string name, string email, int page = 1)
        {
            ViewBag.name = name;
            ViewBag.email = email;

            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            AdminViewModel avm = new AdminViewModel();

            var response = await GlobalVariables.MyHttpClient.client.
                            GetAsync("managers?name=" + name + "&email=" + email);

            var res = await response.Content.ReadAsStringAsync();

            List<Manager> List = JsonConvert.DeserializeObject<List<Manager>>(res);

            if (List == null)
            {
                return Redirect("~/Admin/Login");
            }

            avm.manaList = (PagedList<Manager>)List.ToPagedList<Manager>(page, Limit);

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res1 = await response1.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res1);

            if (avm == null)
            {
                return Redirect("~/Admin/Login");
            }

            return View(avm);
        }

        [Route("Admin/Managers/Detail/{id}")]
        public async Task<ActionResult> Detail(string id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            AdminViewModel avm = new AdminViewModel();

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("managers/" + id);

            var res = await response.Content.ReadAsStringAsync();

            avm.managerInfo = JsonConvert.DeserializeObject<Manager>(res);

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res1 = await response1.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res1);

            return View(avm);
        }

        [Route("Admin/Managers/Edit/{id}")]
        public async Task<ActionResult> Edit(string id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            AdminViewModel avm = new AdminViewModel();

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("managers/" + id);

            var res = await response.Content.ReadAsStringAsync();

            avm.managerInfo = JsonConvert.DeserializeObject<Manager>(res);

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res1 = await response1.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res1);

            return View(avm);
        }

        [HttpPost]
        [Route("Admin/Managers/Edit/{id}")]
        public async Task<IActionResult> Edit([Bind("managerInfo")] AdminViewModel avm)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res = await response.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res);

            if (ModelState.IsValid)
            {
                bool usernameDuplicate = checkUsernameDuplicateAsync(avm.managerInfo.Username, avm.managerInfo.AdminId.ToString()).Result;
                bool emailDuplicate = checkEmailDuplicateAsync(avm.managerInfo.Email, avm.managerInfo.AdminId.ToString()).Result;

                if (usernameDuplicate)
                {
                    ModelState.AddModelError("managerInfo.Username", "Username existed.");
                    return View(avm);
                }
                if (emailDuplicate)
                {
                    ModelState.AddModelError("managerInfo.Email", "Email existed.");
                    return View(avm);
                }

                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0 && files[0].Length > 0)
                {
                    var file = files[0];
                    var fileName = file.FileName;

                    // Upload
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\AdminImages", fileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        avm.managerInfo.Image = fileName;
                    }
                }

                var result = await GlobalVariables.MyHttpClient.client
                    .PutAsync("managers/" + avm.managerInfo.AdminId, new StringContent(JsonConvert.SerializeObject(avm.managerInfo), Encoding.UTF8, "application/json"));

                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Messages = "Update Successful";
                    return RedirectToAction("Index");
                }

            }

            return View(avm);
        }

        [Route("Admin/Managers/Create")]
        public async Task<IActionResult> CreateAsync()
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            AdminViewModel avm = new AdminViewModel();

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res = await response.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res);

            return View(avm);
        }

        [HttpPost]
        [Route("Admin/Managers/Create")]
        public async Task<IActionResult> Create([Bind("managerInfo")] AdminViewModel avm)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res = await response.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res);

            if (ModelState.IsValid)
            {
                bool usernameDuplicate = checkUsernameDuplicateAsync(avm.managerInfo.Username, avm.managerInfo.AdminId.ToString()).Result;
                bool emailDuplicate = checkEmailDuplicateAsync(avm.managerInfo.Email, avm.managerInfo.AdminId.ToString()).Result;

                if (usernameDuplicate)
                {
                    ModelState.AddModelError("managerInfo.Username", "Username existed.");
                    return View(avm);
                }
                if (emailDuplicate)
                {
                    ModelState.AddModelError("managerInfo.Email", "Email existed.");
                    return View(avm);
                }

                avm.managerInfo.Created_date = DateTime.Now;

                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0 && files[0].Length > 0)
                {
                    var file = files[0];
                    var fileName = file.FileName;

                    // Upload
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\AdminImages", fileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        avm.managerInfo.Image = fileName;
                    }
                }

                var result = await GlobalVariables.MyHttpClient.client
                    .PostAsync("managers", new StringContent(JsonConvert.SerializeObject(avm.managerInfo), Encoding.UTF8, "application/json"));

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(avm);
        }

        public async Task<bool> checkUsernameDuplicateAsync(string username, string id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("managers");

            var res = await response.Content.ReadAsStringAsync();

            List<Manager> manaList = JsonConvert.DeserializeObject<List<Manager>>(res);
            foreach (var m in manaList)
            {
                if (username.Equals(m.Username) && m.AdminId.ToString().Equals(id))
                {
                    continue;
                }
                if (username.Equals(m.Username))
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> checkEmailDuplicateAsync(string email, string id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("managers");

            var res = await response.Content.ReadAsStringAsync();

            List<Manager> manaList = JsonConvert.DeserializeObject<List<Manager>>(res);
            foreach (var m in manaList)
            {
                if (email.Equals(m.Email) && m.AdminId.ToString().Equals(id))
                {
                    continue;
                }
                if (email.Equals(m.Email))
                {
                    return true;
                }
            }

            return false;
        }

        [HttpPost, ActionName("Delete")]
        [Route("Admin/Managers")]
        public async Task<IActionResult> Delete(string id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var totalManager = checkTotalManager().Result;

            if (totalManager == 1 || totalManager < 2)
            {
                ViewBag.ErrorMessages = "Must have at least 2 managers to delete!";
            }
            else
            {
                var result = await GlobalVariables.MyHttpClient.client.DeleteAsync("managers/" + id);
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Messages = "Delete Success";
                }
                else
                {
                    ViewBag.ErrorMessages = "Delete Failed";
                }
            }
            AdminViewModel avm = new AdminViewModel();

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("managers");

            var res = await response.Content.ReadAsStringAsync();

            List<Manager> List = JsonConvert.DeserializeObject<List<Manager>>(res);

            avm.manaList = (PagedList<Manager>)List.ToPagedList<Manager>(1, Limit);

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res1 = await response1.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res1);

            return View("Index", avm);
        }

        public async Task<int> checkTotalManager()
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("managers");

            var res = await response.Content.ReadAsStringAsync();

            List<Manager> List = JsonConvert.DeserializeObject<List<Manager>>(res);

            return List.Count;
        }
    }
}
