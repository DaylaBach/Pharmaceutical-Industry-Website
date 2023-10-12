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
    public class CategoriesController : Controller
    {
        bool IsDuplicate;
        int Limit = 2;

        [Route("Admin/Categories")]
        public async Task<ActionResult> Index(string name, int? status, DateTime startDate, DateTime endDate, int page = 1)
        {
            ViewBag.name = name;
            ViewBag.status = status;
            ViewBag.startDate = startDate;
            ViewBag.endDate = endDate;

            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            AdminViewModel avm = new AdminViewModel();

            var response = await GlobalVariables.MyHttpClient.client.
                            GetAsync("categories?name="+name+"&status="+status+"&startDate="+startDate +"&endDate="+endDate);

            var res = await response.Content.ReadAsStringAsync();

            List<Category> List = JsonConvert.DeserializeObject<List<Category>>(res);

            if (List == null)
            {
                return Redirect("~/Admin/Login");
            }

            avm.catList = (PagedList<Category>)List.ToPagedList<Category>(page, Limit);

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res1 = await response1.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res1);

            return View(avm);
        }

        [Route("Admin/Categories/Detail/{id}")]
        public async Task<ActionResult> Detail(int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            AdminViewModel avm = new AdminViewModel();

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("categories/" + id);

            var res = await response.Content.ReadAsStringAsync();

            avm.category = JsonConvert.DeserializeObject<Category>(res);

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res1 = await response1.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res1);

            return View(avm);
        }

        [Route("Admin/Categories/Edit/{id}")]
        public async Task<ActionResult> Edit(int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            AdminViewModel avm = new AdminViewModel();

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("categories/" + id);

            var res = await response.Content.ReadAsStringAsync();

            avm.category = JsonConvert.DeserializeObject<Category>(res);

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res1 = await response1.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res1);

            return View(avm);
        }

        [HttpPost]
        [Route("Admin/Categories/Edit/{id}")]
        public async Task<IActionResult> Edit([Bind("category")] AdminViewModel avm)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res = await response.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res);

            if (ModelState.IsValid)
            {
                IsDuplicate = checkNameDuplicateAsync(avm.category.CategoryName, avm.category.CategoryId).Result;

                if (IsDuplicate)
                {
                    ModelState.AddModelError("category.CategoryName", "Category existed.");
                    return View(avm);
                }

                var result = await GlobalVariables.MyHttpClient.client
                    .PutAsync("categories/" + avm.category.CategoryId, new StringContent(JsonConvert.SerializeObject(avm.category), Encoding.UTF8, "application/json"));

                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Messages = "Update Successful";
                    return RedirectToAction("Index");
                }

            }

            return View(avm);
        }

        [Route("Admin/Categories/Create")]
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
        [Route("Admin/Categories/Create")]
        public async Task<IActionResult> Create([Bind("category")] AdminViewModel avm)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res = await response.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res);

            if (ModelState.IsValid)
            {
                avm.category.CreatedDate = DateTime.Now;

                IsDuplicate = checkNameDuplicateAsync(avm.category.CategoryName, 0).Result;

                if (IsDuplicate)
                {
                    ModelState.AddModelError("category.CategoryName", "Category existed.");
                    return View(avm);
                }

                var result = await GlobalVariables.MyHttpClient.client
                    .PostAsync("categories", new StringContent(JsonConvert.SerializeObject(avm.category), Encoding.UTF8, "application/json"));

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(avm);
        }

        public async Task<bool> checkNameDuplicateAsync(string name, int id)
        {
            var response = await GlobalVariables.MyHttpClient.client.GetAsync("categories");

            var res = await response.Content.ReadAsStringAsync();

            List<Category> catList = JsonConvert.DeserializeObject<List<Category>>(res);
            foreach (var c in catList)
            {
                if (name.Equals(c.CategoryName) && c.CategoryId.Equals(id))
                {
                    continue;
                }
                if (name.Equals(c.CategoryName))
                {
                    return true;
                }
            }

            return false;
        }

        [HttpPost, ActionName("Delete")]
        [Route("Admin/Categories")]
        public async Task<IActionResult> Delete(int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            AdminViewModel avm = new AdminViewModel();

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res = await response.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res);

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("categories/" + id);

            var res1 = await response1.Content.ReadAsStringAsync();

            avm.category = JsonConvert.DeserializeObject<Category>(res1);

            if (avm.category.Products.Count > 0)
            {
                ViewBag.ErrorMessages = "Cannot delete category that contain product(s)";
                return View("Index", avm);
            }

            var result = await GlobalVariables.MyHttpClient.client.DeleteAsync("categories/" + id);
            if (result.IsSuccessStatusCode)
            {
                ViewBag.Messages = "Delete Success";
            } 
            else
            {
                ViewBag.ErrorMessages = "Delete Failed";
            }

            var response2 = await GlobalVariables.MyHttpClient.client.GetAsync("categories");

            var res2 = await response2.Content.ReadAsStringAsync();

            List<Category> List = JsonConvert.DeserializeObject<List<Category>>(res2);

            avm.catList = (PagedList<Category>)List.ToPagedList<Category>(1, Limit);

            return View("Index", avm);
        }
    }
}
