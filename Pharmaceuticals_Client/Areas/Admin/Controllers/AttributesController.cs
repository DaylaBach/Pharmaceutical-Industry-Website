using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class AttributesController : Controller
    {
        int Limit = 2;

        [Route("Admin/Attributes")]
        public async Task<ActionResult> Index(string name, string product, int page = 1)
        {
            ViewBag.name = name;
            ViewBag.product = product;

            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            AdminViewModel avm = new AdminViewModel();

            var response = await GlobalVariables.MyHttpClient.client.
                            GetAsync("attributes?name=" + name + "&product=" + product);

            var res = await response.Content.ReadAsStringAsync();

            List<Pharmaceuticals_Client.Models.Attribute> List = JsonConvert.DeserializeObject<List<Pharmaceuticals_Client.Models.Attribute>>(res);

            if (List == null)
            {
                return Redirect("~/Admin/Login");
            }

            avm.attList = (PagedList<Pharmaceuticals_Client.Models.Attribute>)List.ToPagedList<Pharmaceuticals_Client.Models.Attribute>(page, Limit);

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("products");

            var res1 = await response1.Content.ReadAsStringAsync();

            List<Product> proList = JsonConvert.DeserializeObject<List<Product>>(res1);

            if (proList == null)
            {
                return Redirect("~/Admin/Login");
            }

            ViewBag.products = new SelectList(proList, "ProductId", "ProductName");

            var response2 = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res2 = await response2.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res2);

            return View(avm);
        }

        [Route("Admin/Attributes/Detail/{id}")]
        public async Task<ActionResult> Detail(int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            AdminViewModel avm = new AdminViewModel();

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("attributes/" + id);

            var res = await response.Content.ReadAsStringAsync();

            avm.attribute = JsonConvert.DeserializeObject<Pharmaceuticals_Client.Models.Attribute>(res);

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res1 = await response1.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res1);

            return View(avm);
        }

        [Route("Admin/Attributes/Edit/{id}")]
        public async Task<ActionResult> Edit(int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("attributes/" + id);

            var res = await response.Content.ReadAsStringAsync();

            AdminViewModel avm = new AdminViewModel();

            avm.attribute = JsonConvert.DeserializeObject<Pharmaceuticals_Client.Models.Attribute>(res);

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("products");

            var res1 = await response1.Content.ReadAsStringAsync();

            List<Product> proList = JsonConvert.DeserializeObject<List<Product>>(res1);

            if (proList == null)
            {
                return Redirect("~/Admin/Login");
            }

            ViewBag.products = new SelectList(proList, "ProductId", "ProductName");

            var response2 = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res2 = await response2.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res2);

            return View(avm);
        }

        [HttpPost]
        [Route("Admin/Attributes/Edit/{id}")]
        public async Task<IActionResult> Edit([Bind("attribute")] AdminViewModel avm)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            if (ModelState.IsValid)
            {
                var result = await GlobalVariables.MyHttpClient.client
                    .PutAsync("attributes/" + avm.attribute.AttributeId, new StringContent(JsonConvert.SerializeObject(avm.attribute), Encoding.UTF8, "application/json"));

                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Messages = "Update Successful";
                    return RedirectToAction("Index");
                }

            }
            var response = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res = await response.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res);

            return View(avm);
        }

        [Route("Admin/Attributes/Create")]
        public async Task<IActionResult> Create()
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            AdminViewModel avm = new AdminViewModel();

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("products");

            var res = await response.Content.ReadAsStringAsync();

            List<Product> proList = JsonConvert.DeserializeObject<List<Product>>(res);

            if (proList == null)
            {
                return Redirect("~/Admin/Login");
            }

            ViewBag.products = new SelectList(proList, "ProductId", "ProductName");

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res1 = await response1.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res1);

            return View(avm);
        }

        [HttpPost]
        [Route("Admin/Attributes/Create")]
        public async Task<IActionResult> Create([Bind("attribute")] AdminViewModel avm)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            if (ModelState.IsValid)
            {
                var result = await GlobalVariables.MyHttpClient.client
                    .PostAsync("attributes", new StringContent(JsonConvert.SerializeObject(avm.attribute), Encoding.UTF8, "application/json"));

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            var response = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res = await response.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res);

            return View(avm);
        }

        [HttpPost, ActionName("Delete")]
        [Route("Admin/Attributes")]
        public async Task<IActionResult> Delete(int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            AdminViewModel avm = new AdminViewModel();

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res = await response.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res);

            var result = await GlobalVariables.MyHttpClient.client.DeleteAsync("attributes/" + id);
            if (result.IsSuccessStatusCode)
            {
                ViewBag.Messages = "Delete Success";
            }
            else
            {
                ViewBag.ErrorMessages = "Delete Failed";
            }

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("attributes");

            var res1 = await response1.Content.ReadAsStringAsync();

            List<Pharmaceuticals_Client.Models.Attribute> List = JsonConvert.DeserializeObject<List<Pharmaceuticals_Client.Models.Attribute>>(res1);

            avm.attList = (PagedList<Pharmaceuticals_Client.Models.Attribute>)List.ToPagedList<Pharmaceuticals_Client.Models.Attribute>(1, Limit);

            return View("Index", avm);
        }
    }
}
