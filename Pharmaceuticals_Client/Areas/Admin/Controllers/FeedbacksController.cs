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
    public class FeedbacksController : Controller
    {
        bool IsDuplicate;
        int Limit = 5;

        [Route("Admin/Feedbacks")]
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
                            GetAsync("feedbacks?name=" + name + "&address=" + address + "&email=" + email + "&phone=" + phone + "&startDate=" + startDate + "&endDate=" + endDate);

            var res = await response.Content.ReadAsStringAsync();

            List<Feedback> List = JsonConvert.DeserializeObject<List<Feedback>>(res);

            if (List == null)
            {
                return Redirect("~/Admin/Login");
            }

            avm.feedbackList = (PagedList<Feedback>)List.ToPagedList<Feedback>(page, Limit);

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res1 = await response1.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res1);

            return View(avm);
        }

        [Route("Admin/Feedbacks/Detail/{id}")]
        public async Task<ActionResult> Detail(int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            AdminViewModel avm = new AdminViewModel();

            // Lấy thông tin detail category ra và gán vào category của AdminViewModel
            var response = await GlobalVariables.MyHttpClient.client.GetAsync("feedbacks/" + id);

            var res = await response.Content.ReadAsStringAsync();

            avm.feedback = JsonConvert.DeserializeObject<Feedback>(res);

            // Lấy ra thông tin của admin vừa đăng nhập bằng Username xong gán vào manager của AdminViewModel
            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res1 = await response1.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res1);

            return View(avm);
        }

        [Route("Admin/Feedbacks/Edit/{id}")]
        public async Task<ActionResult> Edit(int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            AdminViewModel avm = new AdminViewModel();

            // Lấy thông tin detail category ra và gán vào category của AdminViewModel
            var response = await GlobalVariables.MyHttpClient.client.GetAsync("feedbacks/" + id);

            var res = await response.Content.ReadAsStringAsync();

            avm.feedback = JsonConvert.DeserializeObject<Feedback>(res);

            // Lấy ra thông tin của admin vừa đăng nhập bằng Username xong gán vào manager của AdminViewModel
            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res1 = await response1.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res1);

            return View(avm);
        }

        [HttpPost]
        [Route("Admin/Feedbacks/Edit/{id}")]
        public async Task<IActionResult> Edit([Bind("feedback")] AdminViewModel avm) // Truyền model là AdminViewModel và gắn nó với category
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            // Lấy ra thông tin của admin vừa đăng nhập bằng Username xong gán vào manager của AdminViewModel
            var response = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res = await response.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res);

            if (ModelState.IsValid)
            {
                // check trùng tên category
                IsDuplicate = checkNameDuplicateAsync(avm.feedback.FullName, avm.feedback.FeedbackId).Result;

                if (IsDuplicate)
                {
                    // nếu trùng thì thêm lỗi để hiện ra
                    ModelState.AddModelError("feedback.FullName", "Feedback existed.");
                    return View(avm);
                }

                var result = await GlobalVariables.MyHttpClient.client
                    .PutAsync("feedbacks/" + avm.feedback.FeedbackId, new StringContent(JsonConvert.SerializeObject(avm.feedback), Encoding.UTF8, "application/json"));

                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Messages = "Update Successful";
                    return RedirectToAction("Index");
                }

            }

            return View(avm);
        }

        [Route("Admin/Feedbacks/Create")]
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
        [Route("Admin/Feedbacks/Create")]
        public async Task<IActionResult> Create([Bind("feedback")] AdminViewModel avm) // Truyền model là AdminViewModel và gắn nó với category
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res = await response.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res);

            if (ModelState.IsValid)
            {
                avm.feedback.Created_date = DateTime.Now;

                IsDuplicate = checkNameDuplicateAsync(avm.feedback.FullName, 0).Result;

                if (IsDuplicate)
                {
                    ModelState.AddModelError("feedback.FullName", "Feedback existed.");
                    return View(avm);
                }

                var result = await GlobalVariables.MyHttpClient.client
                    .PostAsync("feedbacks", new StringContent(JsonConvert.SerializeObject(avm.feedback), Encoding.UTF8, "application/json"));

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(avm);
        }

        public async Task<bool> checkNameDuplicateAsync(string name, int id)
        {
            var response = await GlobalVariables.MyHttpClient.client.GetAsync("feedbacks");

            var res = await response.Content.ReadAsStringAsync();

            List<Feedback> feedbackList = JsonConvert.DeserializeObject<List<Feedback>>(res);
            foreach (var f in feedbackList)
            {
                // Check nếu trùng cả tên và id thì thoát luôn vòng lặp, nếu k thì để nguyên tên k sửa ở edit nó cũng báo trùng
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

        [HttpPost, ActionName("Delete")]
        [Route("Admin/Feedbacks")]
        public async Task<IActionResult> Delete(int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            AdminViewModel avm = new AdminViewModel();

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res = await response.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res);

            // Lấy ra category đang muốn xóa và check xem nó có product không, có thì k được xóa
            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("feedbacks/" + id);

            var res1 = await response1.Content.ReadAsStringAsync();

            avm.feedback = JsonConvert.DeserializeObject<Feedback>(res1);



            var result = await GlobalVariables.MyHttpClient.client.DeleteAsync("feedbacks/" + id);
            if (result.IsSuccessStatusCode)
            {
                ViewBag.Messages = "Delete Success";
            }
            else
            {
                ViewBag.ErrorMessages = "Delete Failed";
            }

            // Lấy ra list category để truyền lại vào index
            var response2 = await GlobalVariables.MyHttpClient.client.GetAsync("feedbacks");

            var res2 = await response2.Content.ReadAsStringAsync();

            List<Feedback> List = JsonConvert.DeserializeObject<List<Feedback>>(res2);

            avm.feedbackList = (PagedList<Feedback>)List.ToPagedList<Feedback>(1, Limit);

            return View("Index", avm);
        }


    }
}
