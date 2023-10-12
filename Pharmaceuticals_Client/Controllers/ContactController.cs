using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pharmaceuticals_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Pharmaceuticals_Client.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
