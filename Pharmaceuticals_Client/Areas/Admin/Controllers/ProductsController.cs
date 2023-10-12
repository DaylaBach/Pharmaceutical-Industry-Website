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
    public class ProductsController : Controller
    {
        int Limit = 2;

        [Route("Admin/Products")]
        public async Task<ActionResult> Index(string name, string modelNumber, int? category, int? manufacturer, DateTime startDate, DateTime endDate, int page = 1)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            ViewBag.name = name;
            ViewBag.modelNumber = modelNumber;
            ViewBag.category = category;
            ViewBag.manufacturer = manufacturer;
            ViewBag.startDate = startDate;
            ViewBag.endDate = endDate;

            AdminViewModel avm = new AdminViewModel();

            var response = await GlobalVariables.MyHttpClient.client.
                        GetAsync("products?name=" + name + "&modelNumber=" + modelNumber + "&category=" + category + "&manufacturer=" + manufacturer + "&startDate=" + startDate + "&endDate=" + endDate);

            var res = await response.Content.ReadAsStringAsync();

            List<Product> List = JsonConvert.DeserializeObject<List<Product>>(res);

            if (List == null)
            {
                return Redirect("~/Admin/Login");
            }

            avm.proList = (PagedList<Product>)List.ToPagedList<Product>(page, Limit);

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("categories");

            var res1 = await response1.Content.ReadAsStringAsync();

            List<Category> catList = JsonConvert.DeserializeObject<List<Category>>(res1);

            if (catList == null)
            {
                return Redirect("~/Admin/Login");
            }

            ViewBag.categories = new SelectList(catList, "CategoryId", "CategoryName");

            var response2 = await GlobalVariables.MyHttpClient.client.GetAsync("manufacturers");

            var res2 = await response2.Content.ReadAsStringAsync();

            List<Manufacturer> manuList = JsonConvert.DeserializeObject<List<Manufacturer>>(res2);

            if (manuList == null)
            {
                return Redirect("~/Admin/Login");
            }

            ViewBag.manufacturers = new SelectList(manuList, "ManufacturerId", "ManufacturerName");

            var response3 = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res3 = await response3.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res3);

            return View(avm);
        }

        [Route("Admin/Products/Detail/{id}")]
        public async Task<ActionResult> Detail(string id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            AdminViewModel avm = new AdminViewModel();

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("products/" + id);

            var res = await response.Content.ReadAsStringAsync();

            avm.product = JsonConvert.DeserializeObject<Product>(res);

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res1 = await response1.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res1);

            return View(avm);
        }

        [Route("Admin/Products/Edit/{id}")]
        public async Task<ActionResult> Edit(string id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            AdminViewModel avm = new AdminViewModel();

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("products/" + id);

            var res = await response.Content.ReadAsStringAsync();

            avm.product = JsonConvert.DeserializeObject<Product>(res);

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("categories");

            var res1 = await response1.Content.ReadAsStringAsync();

            List<Category> catList = JsonConvert.DeserializeObject<List<Category>>(res1);

            ViewBag.categories = new SelectList(catList, "CategoryId", "CategoryName");

            var response2 = await GlobalVariables.MyHttpClient.client.GetAsync("manufacturers");

            var res2 = await response2.Content.ReadAsStringAsync();

            List<Manufacturer> manuList = JsonConvert.DeserializeObject<List<Manufacturer>>(res2);

            ViewBag.manufacturers = new SelectList(manuList, "ManufacturerId", "ManufacturerName");

            var response3 = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res3 = await response3.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res3);

            return View(avm);
        }

        [HttpPost]
        [Route("Admin/Products/Edit/{id}")]
        public async Task<IActionResult> Edit([Bind("product")] AdminViewModel avm)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0 && files[0].Length > 0)
                {
                    var file = files[0];
                    var fileName = file.FileName;

                    // Upload
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Products", fileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        avm.product.ProductImage = fileName;
                    }
                }

                var result = await GlobalVariables.MyHttpClient.client
                    .PutAsync("products/" + avm.product.ProductId, new StringContent(JsonConvert.SerializeObject(avm.product), Encoding.UTF8, "application/json"));

                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Messages = "Update Successful";
                    return RedirectToAction("Index");
                }

            }

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res1 = await response1.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res1);

            return View(avm);
        }

        [Route("Admin/Products/Create")]
        public async Task<IActionResult> Create()
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            AdminViewModel avm = new AdminViewModel();

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("categories");

            var res1 = await response1.Content.ReadAsStringAsync();

            List<Category> catList = JsonConvert.DeserializeObject<List<Category>>(res1);

            ViewBag.categories = new SelectList(catList, "CategoryId", "CategoryName");

            var response2 = await GlobalVariables.MyHttpClient.client.GetAsync("manufacturers");

            var res2 = await response2.Content.ReadAsStringAsync();

            List<Manufacturer> manuList = JsonConvert.DeserializeObject<List<Manufacturer>>(res2);

            ViewBag.manufacturers = new SelectList(manuList, "ManufacturerId", "ManufacturerName");

            var response3 = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res3 = await response3.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res3);

            return View(avm);
        }

        [HttpPost]
        [Route("Admin/Products/Create")]
        public async Task<IActionResult> Create([Bind("product")] AdminViewModel avm)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            if (ModelState.IsValid)
            {
                avm.product.CreatedDate = DateTime.Now;

                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0 && files[0].Length > 0)
                {
                    var file = files[0];
                    var fileName = file.FileName;

                    // Upload
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Products", fileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        avm.product.ProductImage = fileName;
                    }
                }

                var result = await GlobalVariables.MyHttpClient.client
                    .PostAsync("products", new StringContent(JsonConvert.SerializeObject(avm.product), Encoding.UTF8, "application/json"));

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }

            var response3 = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res3 = await response3.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res3);

            return View(avm);
        }

        [HttpPost, ActionName("Delete")]
        [Route("Admin/Products")]
        public async Task<IActionResult> Delete(string id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var result = await GlobalVariables.MyHttpClient.client.DeleteAsync("products/" + id);
            if (result.IsSuccessStatusCode)
            {
                ViewBag.Messages = "Delete Success";
            }
            else
            {
                ViewBag.ErrorMessages = "Delete Failed";
            }

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("products");

            var res = await response.Content.ReadAsStringAsync();

            AdminViewModel avm = new AdminViewModel();

            List<Product> List = JsonConvert.DeserializeObject<List<Product>>(res);

            avm.proList = (PagedList<Product>)List.ToPagedList<Product>(1, Limit);

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res1 = await response1.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res1);

            return View("Index", avm);
        }
    }
}
