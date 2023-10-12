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
    public class CandidatesController : Controller
    {
        int Limit = 2;

        [Route("Admin/Candidates")]
        public async Task<ActionResult> Index(string name, string phone, string email, string education, DateTime startDate, DateTime endDate, int page = 1)
        {
            ViewBag.name = name;
            ViewBag.phone = phone;
            ViewBag.email = email;
            ViewBag.education = education;
            ViewBag.startDate = startDate;
            ViewBag.endDate = endDate;

            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            AdminViewModel avm = new AdminViewModel();

            var response = await GlobalVariables.MyHttpClient.client.
                            GetAsync("candidates?name=" + name + "&phone=" + phone + "&email=" + email + "&education=" + education + "&startDate=" + startDate + "&endDate=" + endDate);

            var res = await response.Content.ReadAsStringAsync();

            List<Candidate> List = JsonConvert.DeserializeObject<List<Candidate>>(res);

            if (List == null)
            {
                return Redirect("~/Admin/Login");
            }

            avm.canList = (PagedList<Candidate>)List.ToPagedList<Candidate>(page, Limit);

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res1 = await response1.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res1);

            return View(avm);
        }

        [Route("Admin/Candidates/Detail/{id}")]
        public async Task<ActionResult> Detail(int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            AdminViewModel avm = new AdminViewModel();

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("candidates/" + id);

            var res = await response.Content.ReadAsStringAsync();

            avm.candidate = JsonConvert.DeserializeObject<Candidate>(res);

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res1 = await response1.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res1);

            return View(avm);
        }

        [Route("Admin/Candidates/Edit/{id}")]
        public async Task<ActionResult> Edit(int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            AdminViewModel avm = new AdminViewModel();

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("candidates/" + id);

            var res = await response.Content.ReadAsStringAsync();

            avm.candidate = JsonConvert.DeserializeObject<Candidate>(res);

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res1 = await response1.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res1);

            return View(avm);
        }

        [HttpPost]
        [Route("Admin/Candidates/Edit/{id}")]
        public async Task<IActionResult> Edit([Bind("candidate")] AdminViewModel avm)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res = await response.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res);

            if (ModelState.IsValid)
            {
                if (checkEmailDuplicateAsync(avm.candidate.Email, avm.candidate.CandidateId).Result)
                {
                    ModelState.AddModelError("candidate.Email", "Email existed.");
                    return View(avm);
                }

                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0 && files[0].Length > 0)
                {
                    foreach (var item in files)
                    {
                        if (item.Name.Equals("Resume"))
                        {
                            var file = item;
                            var fileName = file.FileName;

                            // Upload
                            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\resumes", fileName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                file.CopyTo(stream);
                                avm.candidate.Resume = fileName;
                            }
                        }
                        if (item.Name.Equals("Image"))
                        {
                            var file = item;
                            var fileName = file.FileName;

                            // Upload
                            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\candidateImages", fileName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                file.CopyTo(stream);
                                avm.candidate.Image = fileName;
                            }
                        }
                    }
                }

                var result = await GlobalVariables.MyHttpClient.client
                    .PutAsync("candidates/" + avm.candidate.CandidateId, new StringContent(JsonConvert.SerializeObject(avm.candidate), Encoding.UTF8, "application/json"));

                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Messages = "Update Successful";
                    return RedirectToAction("Index");
                }

            }

            return View(avm);
        }

        [Route("Admin/Candidates/Create")]
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
        [Route("Admin/Candidates/Create")]
        public async Task<IActionResult> Create([Bind("candidate")] AdminViewModel avm)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res = await response.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res);

            if (ModelState.IsValid)
            {
                avm.candidate.Created_date = DateTime.Now;

                if (checkEmailDuplicateAsync(avm.candidate.Email, avm.candidate.CandidateId).Result)
                {
                    ModelState.AddModelError("candidate.Email", "Email existed.");
                    return View(avm);
                }

                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0 && files[0].Length > 0)
                {
                    foreach (var item in files)
                    {
                        if (item.Name.Equals("Resume"))
                        {
                            var file = item;
                            var fileName = file.FileName;

                            // Upload
                            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\resumes", fileName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                file.CopyTo(stream);
                                avm.candidate.Resume = fileName;
                            }
                        }
                        if (item.Name.Equals("Image"))
                        {
                            var file = item;
                            var fileName = file.FileName;

                            // Upload
                            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\candidateImages", fileName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                file.CopyTo(stream);
                                avm.candidate.Image = fileName;
                            }
                        }
                    }
                }

                if (avm.candidate.Resume.Equals("NoResume"))
                {
                    ModelState.AddModelError("Resume", "Please upload your Resume");
                    return View(avm);
                }

                var result = await GlobalVariables.MyHttpClient.client
                    .PostAsync("candidates", new StringContent(JsonConvert.SerializeObject(avm.category), Encoding.UTF8, "application/json"));

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(avm);
        }

        public async Task<bool> checkEmailDuplicateAsync(string email, int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("candidates");

            var res = await response.Content.ReadAsStringAsync();

            List<Candidate> canList = JsonConvert.DeserializeObject<List<Candidate>>(res);
            foreach (var c in canList)
            {
                if (email.Equals(c.Email) && c.CandidateId.Equals(id))
                {
                    continue;
                }
                if (email.Equals(c.Email))
                {
                    return true;
                }
            }

            return false;
        }

        [HttpPost, ActionName("Delete")]
        [Route("Admin/Candidates")]
        public async Task<IActionResult> Delete(int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            AdminViewModel avm = new AdminViewModel();

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("managers/Username?username=" + HttpContext.Session.GetString("AdminUsername"));

            var res = await response.Content.ReadAsStringAsync();

            avm.manager = JsonConvert.DeserializeObject<Manager>(res);

            var result = await GlobalVariables.MyHttpClient.client.DeleteAsync("candidates/" + id);
            if (result.IsSuccessStatusCode)
            {
                ViewBag.Messages = "Delete Success";
            }
            else
            {
                ViewBag.ErrorMessages = "Delete Failed";
            }

            var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("candidates");

            var res1 = await response1.Content.ReadAsStringAsync();

            List<Candidate> List = JsonConvert.DeserializeObject<List<Candidate>>(res1);

            avm.canList = (PagedList<Candidate>)List.ToPagedList<Candidate>(1, Limit);

            return View("Index", avm);
        }

        [HttpGet("Admin/Candidates/Download")]
        public async Task<IActionResult> Download(int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            GlobalVariables.MyHttpClient.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            AdminViewModel avm = new AdminViewModel();

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("candidates/" + id);

            var res = await response.Content.ReadAsStringAsync();

            avm.candidate = JsonConvert.DeserializeObject<Candidate>(res);

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\resumes", avm.candidate.Resume);

            var net = new System.Net.WebClient();
            var data = net.DownloadData(path);
            var content = new MemoryStream(data);
            var contentType = "APPLICATION/octet-stream";

            return File(content, contentType, avm.candidate.Resume);
        }
    }
}
