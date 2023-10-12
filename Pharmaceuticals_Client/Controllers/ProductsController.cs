using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pharmaceuticals_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using X.PagedList;

namespace Pharmaceuticals_Client.Controllers
{
    public class ProductsController : Controller
    {
        int Limit = 3;
        public async Task<ActionResult> Index(string name, string modelNumber, int? category, int? manufacturer, DateTime startDate, DateTime endDate, int? cateId, int page = 1)
        {
            ViewBag.name = name;
            ViewBag.modelNumber = modelNumber;
            ViewBag.category = category;
            ViewBag.manufacturer = manufacturer;
            ViewBag.startDate = startDate;
            ViewBag.endDate = endDate;

            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await GlobalVariables.MyHttpClient.client.
                        GetAsync("products?name=" + name + "&modelNumber=" + modelNumber + "&category=" + category + "&manufacturer=" + manufacturer + "&startDate=" + startDate + "&endDate=" + endDate);

            var res = await response.Content.ReadAsStringAsync();

            UserProductViewModels avm = new UserProductViewModels();

            List<Product> List = JsonConvert.DeserializeObject<List<Product>>(res);

            avm.productList = (PagedList<Product>)List.ToPagedList<Product>(page, Limit);

            //3 product
            var response2 = await GlobalVariables.MyHttpClient.client.GetAsync("products");

            var res2 = await response2.Content.ReadAsStringAsync();

            List<Product> prodList = JsonConvert.DeserializeObject<List<Product>>(res2);

            ViewBag.products = prodList.Take(3);

            //list category
            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("categories");

            var res1 = await response1.Content.ReadAsStringAsync();

            List<Category> catList = JsonConvert.DeserializeObject<List<Category>>(res1);

            //product by category
            cateId = cateId ?? 0;
            if (cateId > 0)
            {
                avm.productList = await List.Where(x => x.CategoryId == cateId).ToPagedListAsync(page, Limit);
            }

            ViewBag.categories = catList;

            return View(avm);
        }
        public async Task<ActionResult> Detail(string id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("products/" + id);

            var res = await response.Content.ReadAsStringAsync();

            UserProductViewModels avm = new UserProductViewModels();

            avm.product = JsonConvert.DeserializeObject<Product>(res);

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("products");

            var res1 = await response1.Content.ReadAsStringAsync();

            List<Product> proList = JsonConvert.DeserializeObject<List<Product>>(res1);
            ViewBag.products = proList.Take(3);

            var response2 = await GlobalVariables.MyHttpClient.client.GetAsync("feedbacks");

            var res2 = await response2.Content.ReadAsStringAsync();

            List<Feedback> feedList = JsonConvert.DeserializeObject<List<Feedback>>(res2);

            ViewBag.feedback = feedList.Take(2);


            return View(avm);
        }
    }
}
