using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quang.Web.API.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Quang.Web.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //List<Category> categories = new List<Category>();
            //HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Helper.Helper.domainUrl}api/category/gets");
            //httpWebRequest.Method = "GET";
            //var response = httpWebRequest.GetResponse();
            //{
            //    string responseData;
            //    Stream responseStream = response.GetResponseStream();
            //    try
            //    {
            //        using (StreamReader sr = new StreamReader(responseStream))
            //        {
            //            responseData = sr.ReadToEnd();
            //        }
            //    }
            //    finally
            //    {
            //        ((IDisposable)responseStream).Dispose();
            //    }
            //    categories = JsonConvert.DeserializeObject<List<Category>>(responseData);
            //}
            List<Manufactory> Manufactories = new List<Manufactory>();
            Manufactories = Helper.ApiHelper<List<Manufactory>>.HttpGetAsync("api/manufactory/gets");
            return View(Manufactories);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateManufactory model)
        {
            if (ModelState.IsValid)
            {
                var result = new CreateManufactoryResult();
                result = Helper.ApiHelper<CreateManufactoryResult>.HttpPostAsync("api/Manufactory/create", "POST", model);
                if (result.ManufactoryId > 0)
                {
                    return RedirectToAction("index");
                }
                ModelState.AddModelError("", result.Message);
                return View(model);
            }
            return View(model);
        }






        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Update(UpdateManufactory model)
        {
            if (ModelState.IsValid)
            {
                var result = new UpdateManufactoryResult();
                result = Helper.ApiHelper<UpdateManufactoryResult>.HttpPostAsync("api/Manufactory/update", "POST", model);
                if (result.ManufactoryId > 0)
                {
                    return RedirectToAction("index");
                }
                ModelState.AddModelError("", result.Message);
                return View(model);
            }
            return View(model);
        }
    }
}