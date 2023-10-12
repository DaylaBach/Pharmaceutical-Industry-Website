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
using X.PagedList;

namespace Pharmaceuticals_Client.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ManufacturersController : Controller
    {
        bool IsDuplicate;
        int Limit = 2;

        [Route("Admin/Manufacturers")]
        public async Task<ActionResult> Index(string name, string address, string email, string phone, DateTime startDate, DateTime endDate, int page = 1)
        {
            ViewBag.name = name;
            ViewBag.address = address;
            ViewBag.email = email;
            ViewBag.phone = phone;
            ViewBag.startDate = startDate;
            ViewBag.endDate = endDate;

            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            AdminViewModel avm = new AdminViewModel();

            var response = await GlobalVariables.MyHttpClient.client.
                            GetAsync("manufacturers?name=" + name + "&address=" + address + "&email=" + email + "&phone=" + phone + "&startDate=" + startDate + "&endDate=" + endDate);

            var res = await response.Content.ReadAsStringAsync();

            List<Manufacturer> List = JsonConvert.DeserializeObject<List<Manufacturer>>(res);

            if (List == null)
            {
                return Redirect("~/Admin/Login");
            }

            avm.manuList = (PagedList<Manufacturer>)List.ToPagedList<Manufacturer>(page, Limit);

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res1 = await response1.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res1);

            return View(avm);
        }

        [Route("Admin/Manufacturers/Detail/{id}")]
        public async Task<ActionResult> Detail(int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            AdminViewModel avm = new AdminViewModel();

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("manufacturers/" + id);

            var res = await response.Content.ReadAsStringAsync();

            avm.manufacturer = JsonConvert.DeserializeObject<Manufacturer>(res);

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res1 = await response1.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res1);

            return View(avm);
        }

        [Route("Admin/Manufacturers/Edit/{id}")]
        public async Task<ActionResult> Edit(int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            AdminViewModel avm = new AdminViewModel();

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("manufacturers/" + id);

            var res = await response.Content.ReadAsStringAsync();

            avm.manufacturer = JsonConvert.DeserializeObject<Manufacturer>(res);

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res1 = await response1.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res1);

            return View(avm);
        }

        [HttpPost]
        [Route("Admin/Manufacturers/Edit/{id}")]
        public async Task<IActionResult> Edit([Bind("manufacturer")] AdminViewModel avm)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res = await response.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res);

            if (ModelState.IsValid)
            {
                IsDuplicate = checkNameDuplicateAsync(avm.manufacturer.ManufacturerName, avm.manufacturer.ManufacturerId).Result;

                if (IsDuplicate)
                {
                    ModelState.AddModelError("manufacturer.ManufacturerName", "Manufacturer existed.");
                    return View(avm);
                }

                var result = await GlobalVariables.MyHttpClient.client
                    .PutAsync("manufacturers/" + avm.manufacturer.ManufacturerId, new StringContent(JsonConvert.SerializeObject(avm.manufacturer), Encoding.UTF8, "application/json"));

                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Messages = "Update Successful";
                    return RedirectToAction("Index");
                }

            }

            return View(avm);
        }

        [Route("Admin/Manufacturers/Create")]
        public async Task<IActionResult> Create()
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
        [Route("Admin/Manufacturers/Create")]
        public async Task<IActionResult> Create([Bind("manufacturer")] AdminViewModel avm)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res = await response.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res);

            if (ModelState.IsValid)
            {
                avm.manufacturer.CreatedDate = DateTime.Now;

                IsDuplicate = checkNameDuplicateAsync(avm.manufacturer.ManufacturerName, 0).Result;

                if (IsDuplicate)
                {
                    ModelState.AddModelError("manufacturer.ManufacturerName", "Manufacturer existed.");
                    return View(avm);
                }

                var result = await GlobalVariables.MyHttpClient.client
                    .PostAsync("manufacturers", new StringContent(JsonConvert.SerializeObject(avm.manufacturer), Encoding.UTF8, "application/json"));

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(avm);
        }

        public async Task<bool> checkNameDuplicateAsync(string name, int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("manufacturers");

            var res = await response.Content.ReadAsStringAsync();

            List<Manufacturer> manuList = JsonConvert.DeserializeObject<List<Manufacturer>>(res);
            foreach (var m in manuList)
            {
                if (name.Equals(m.ManufacturerName) && m.ManufacturerId.Equals(id))
                {
                    continue;
                }
                if (name.Equals(m.ManufacturerName))
                {
                    return true;
                }
            }

            return false;
        }

        [HttpPost, ActionName("Delete")]
        [Route("Admin/Manufacturers")]
        public async Task<IActionResult> Delete(int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            AdminViewModel avm = new AdminViewModel();

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res = await response.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res);

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("manufacturers/" + id);

            var res1 = await response1.Content.ReadAsStringAsync();

            avm.manufacturer = JsonConvert.DeserializeObject<Manufacturer>(res1);

            if (avm.manufacturer.Products.Count > 0)
            {
                ViewBag.ErrorMessages = "Cannot delete manufacturer that contain product(s)";
                return View("Index", avm);
            }

            var result = await GlobalVariables.MyHttpClient.client.DeleteAsync("manufacturers/" + id);
            if (result.IsSuccessStatusCode)
            {
                ViewBag.Messages = "Delete Success";
            }
            else
            {
                ViewBag.ErrorMessages = "Delete Failed";
            }

            var response2 = await GlobalVariables.MyHttpClient.client.GetAsync("manufacturers");

            var res2 = await response2.Content.ReadAsStringAsync();

            List<Manufacturer> List = JsonConvert.DeserializeObject<List<Manufacturer>>(res2);

            avm.manuList = (PagedList<Manufacturer>)List.ToPagedList<Manufacturer>(1, Limit);

            return View("Index", avm);
        }
    }
}
