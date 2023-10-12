using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Pharmaceuticals_Client.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Pharmaceuticals_Client.Controllers
{
    public class CareerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> LoginAsync(string email, string password)
        {
            if (email != null && password != null)
            {
                var response = await GlobalVariables.MyHttpClient.client.GetAsync("candidates/Login?email=" + email + "&password=" + password);

                var res = await response.Content.ReadAsStringAsync();

                Candidate c = JsonConvert.DeserializeObject<Candidate>(res);

                if (c != null)
                {
                    HttpContext.Session.SetString("CandidateId", c.CandidateId.ToString());
                    return Redirect("~/Career/CandidateDetail/" + c.CandidateId);
                } else
                {
                    ViewBag.ErrorMessages = "Invalid credentials";
                    return View();
                }
            }

            ViewBag.ErrorMessages = "Please provide Email and Password to login";

            return View();
        }

        [Route("Career/Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("CandidateId");
            return Redirect("~/Home");
        }

        [Route("Career/CandidateDetail/{id}")]
        public async Task<IActionResult> CandidateDetail(int id)
        {
            if(HttpContext.Session.GetString("CandidateId") == null)
            {
                return Redirect("~/Home/Error404");
            }

            var response = await GlobalVariables.MyHttpClient.client.GetAsync("candidates/" + id);

            var res = await response.Content.ReadAsStringAsync();

            Candidate c = JsonConvert.DeserializeObject<Candidate>(res);

            return View(c);
        }

        [HttpPost]
        [Route("Career/CandidateDetail/{id}")]
        public async Task<IActionResult> CandidateDetail(Candidate c)
        {
            if (ModelState.IsValid)
            {
                var response = await GlobalVariables.MyHttpClient.client.GetAsync("candidates");

                var res = await response.Content.ReadAsStringAsync();

                List<Candidate> canList = JsonConvert.DeserializeObject<List<Candidate>>(res);

                foreach (var can in canList)
                {
                    if (c.Email.Equals(can.Email) && c.CandidateId.Equals(can.CandidateId))
                    {
                        continue;
                    }
                    if (c.Email.Equals(can.Email))
                    {
                        ModelState.AddModelError("Email", "Email existed.");
                        return View(c);
                    }
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
                                c.Resume = fileName;
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
                                c.Image = fileName;
                            }
                        }
                    }
                }

                c.Created_date = DateTime.Now;

                var result = await GlobalVariables.MyHttpClient.client
                    .PutAsync("candidates/" + c.CandidateId, new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json"));

                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Messages = "Update Successful";
                    return View(c);
                } else
                {
                    ViewBag.ErrorMessages = "Update Failed";
                }

            }

            return View(c);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Career/Register")]
        public async Task<IActionResult> Register(Candidate c)
        {            
            if (ModelState.IsValid)
            {
                var response = await GlobalVariables.MyHttpClient.client.GetAsync("candidates");

                var res = await response.Content.ReadAsStringAsync();

                List<Candidate> canList = JsonConvert.DeserializeObject<List<Candidate>>(res);

                foreach (var can in canList)
                {
                    if (c.Email.Equals(can.Email))
                    {
                        ModelState.AddModelError("Email", "Email existed.");
                        return View(c);
                    }
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
                                c.Resume = fileName;
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
                                c.Image = fileName;
                            }
                        }
                    }
                }

                if (c.Resume.Equals("NoResume"))
                {
                    ModelState.AddModelError("Resume", "Please upload your Resume");
                    return View(c);
                }

                c.Created_date = DateTime.Now;

                var result = await GlobalVariables.MyHttpClient.client
                    .PostAsync("candidates", new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json"));

                if (result.IsSuccessStatusCode)
                {
                    var response1 = await GlobalVariables.MyHttpClient.client.GetAsync("candidates/Login?email=" + c.Email + "&password=" + c.Password);

                    var res1 = await response1.Content.ReadAsStringAsync();

                    Candidate can = JsonConvert.DeserializeObject<Candidate>(res1);

                    HttpContext.Session.SetString("CandidateId", c.CandidateId.ToString());

                    return Redirect("~/Career/CandidateDetail/" + can.CandidateId);
                }
            }

            return View(c);
        }

        [HttpPost, ActionName("Delete")]
        [Route("Career")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await GlobalVariables.MyHttpClient.client.DeleteAsync("candidates/" + id);
            if (result.IsSuccessStatusCode)
            {
                ViewBag.Messages = "Delete Success";
                HttpContext.Session.Remove("CandidateId");
            }
            else
            {
                ViewBag.ErrorMessages = "Delete Failed";
            }

            return Redirect("~/Home");
        }
    }
}
